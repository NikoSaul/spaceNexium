using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.Hex.HexTypes;
using Nethereum.HdWallet;
using Nethereum.KeyStore;
using Nethereum.Signer;
using System;
using System.Numerics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Account : MonoBehaviour
{
    public Text debugInfo;

    #region UI Data
    public InputField[] Words = new InputField[12];
    public InputField Password;
    #endregion
    
    private KeyStoreService m_keystoreService = new KeyStoreService();

    private Wallet m_wallet = null;

    private string accountAddress = "";
    private string keystoreJSON = "";
    private string accountPrivateKey = "";

    private string _url = "https://ropsten.infura.io";

    private NexiumContract m_nexiumContract = new NexiumContract();
        
    private void Start()
    {
        Words[0].text = "mixture";
        Words[1].text = "trumpet";
        Words[2].text = "valley";
        Words[3].text = "follow";
        Words[4].text = "sort";
        Words[5].text = "assume";
        Words[6].text = "gesture";
        Words[7].text = "unique";
        Words[8].text = "almost";
        Words[9].text = "brain";
        Words[10].text = "camera";
        Words[11].text = "source";        

        if (LoadJSONFromDisk())
        {
            if (RetrieveAddressFromKeystore())
            {
                // OK
            }
            else
            {
                Debug.Log("Could not retrieve address from existing keystore");
            }
        }
        else
        {
            Debug.Log("No keystore, need to retrieve wallet");
        }        
    }

    #region Wallet & Keystore
    
    public void RetrieveWallet()
    {
        string wordsChain = Words[0].text + " " + Words[1].text + " " + Words[2].text + " " + Words[3].text + " " + Words[4].text + " " + Words[5].text + " " + Words[6].text + " " + Words[7].text + " " + Words[8].text + " " + Words[9].text + " " + Words[10].text + " " + Words[11].text;
        m_wallet = new Wallet(wordsChain, null);

        accountAddress = EthECKey.GetPublicAddress(m_wallet.GetWalletPrivateKeyAsString());

        keystoreJSON = m_keystoreService.EncryptAndGenerateDefaultKeyStoreAsJson(Password.text, m_wallet.GetWalletPrivateKeyAsByte(), accountAddress);
        SaveJSONOnDisk();
    }    

    private bool SaveJSONOnDisk()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/keystore.ks", FileMode.OpenOrCreate);

        if (file == null)
        {
            Debug.LogError("Failed to open the save file");
            return false;
        }

        bf.Serialize(file, keystoreJSON);
        file.Close();

        return true;
    }

    private bool LoadJSONFromDisk()
    {
        if (File.Exists(Application.persistentDataPath + "/keystore.ks"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/keystore.ks", FileMode.Open);

            if (file == null)
            {
                Debug.LogError("Failed to open the save file");
                return false;
            }

            keystoreJSON = (string)bf.Deserialize(file);
            file.Close();

            if (keystoreJSON == null || keystoreJSON == "")
            {
                Debug.LogError("Failed to deserialize the save file");
                return false;
            }

            return true;
        }
        else
            return false;
    }

    private bool RetrieveAddressFromKeystore()
    {
        if (keystoreJSON == null || keystoreJSON == "")
            return false;

        accountAddress = m_keystoreService.GetAddressFromKeyStore(keystoreJSON);
        return true;
    }

    public void RemoveKeyStore()
    {
        keystoreJSON = "";
        accountAddress = "";

        if (File.Exists(Application.persistentDataPath + "/keystore.ks"))
        {
            File.Delete(Application.persistentDataPath + "/keystore.ks");
        }
    }

    IEnumerator GetPrivateKeyFromKeystore(string pass)
    {
        if (keystoreJSON == null || keystoreJSON == "" || pass == null || pass == "")
        {
            accountPrivateKey = "";
            yield break;
        }

        byte[] b = m_keystoreService.DecryptKeyStoreFromJson(pass, keystoreJSON);
        EthECKey myKey = new EthECKey(b, true);

        if (myKey.GetPublicAddress() != accountAddress)
        {
            accountPrivateKey = "";
            yield break;
        }

        accountPrivateKey = myKey.GetPrivateKey();
    }

    #endregion
    
    private IEnumerator getAccountBalance()
    {
        // Now we define a new EthGetBalanceUnityRequest and send it the testnet url where we are going to
        // (we get EthGetBalanceUnityRequest from the Netherum lib imported at the start)
        var getBalanceRequest = new EthGetBalanceUnityRequest("https://ropsten.infura.io");
        // Then we call the method SendRequest() from the getBalanceRequest we created
        // with the address and the newest created block.
        yield return getBalanceRequest.SendRequest(accountAddress, Nethereum.RPC.Eth.DTOs.BlockParameter.CreateLatest());

        // Now we check if the request has an exception
        if (getBalanceRequest.Exception == null)
        {
            // We define balance and assign the value that the getBalanceRequest gave us.
            var balance = getBalanceRequest.Result.Value;
            // Finally we execute the callback and we use the Netherum.Util.UnitConversion
            // to convert the balance from WEI to ETHER (that has 18 decimal places)
            string etherBalance = "ETHER : " + Nethereum.Util.UnitConversion.Convert.FromWei(balance, 18);
        }
        else
        {
            // If there was an error we just throw an exception.
            throw new InvalidOperationException("Get balance request failed");
        }
    }

    public void GetNexiumBalance()
    {
        StartCoroutine(NexiumBalance());
    }

    public IEnumerator NexiumBalance()
    {
        var nexiumBalanceRequest = new EthCallUnityRequest(_url);
        var nexiumBalanceCallInput = m_nexiumContract.Create_balanceOf_Input(accountAddress);

        yield return nexiumBalanceRequest.SendRequest(nexiumBalanceCallInput, Nethereum.RPC.Eth.DTOs.BlockParameter.CreateLatest());        

        // Now we check if the request has an exception
        if (nexiumBalanceRequest.Exception == null)
        {
            string nexium = m_nexiumContract.Decode_balanceOf(nexiumBalanceRequest.Result).ToString();
            string prettyNexium = "NEXIUM : " + nexium.Substring(0, nexium.Length - 3) + "," + nexium.Substring(nexium.Length - 3);

            Debug.Log(prettyNexium);
        }
        else
        {
            // If there was an error we just throw an exception.
            throw new InvalidOperationException("Get Nexium balance request failed");
        }
    }

    public void NexiumApproveTest()
    {
        StartCoroutine(NexiumApprove("0x81b7e08f65bdf5648606c89998a9cc8164397647", 10));
    }

    public IEnumerator NexiumApprove(string spender, BigInteger value)
    {
        accountPrivateKey = "";
        yield return GetPrivateKeyFromKeystore(Password.text);
        
        if (accountPrivateKey == "")
        {
            yield break;
        }        

        var transactionInput = m_nexiumContract.Create_approve_TransactionInput(
            accountAddress,
            accountPrivateKey,
            spender,
            value,
            new HexBigInteger(50000),
            new HexBigInteger(25),
            new HexBigInteger(0)
        );

        // Here we create a new signed transaction Unity Request with the url, private key, and the user address we get before
        // (this will sign the transaction automatically :D )
        var transactionSignedRequest = new TransactionSignedUnityRequest(_url, accountPrivateKey, accountAddress);

        // Then we send it and wait
        yield return transactionSignedRequest.SignAndSendTransaction(transactionInput);

        accountPrivateKey = "";

        if (transactionSignedRequest.Exception == null)
        {
            // If we don't have exceptions we just display the result, congrats!
            Debug.Log("Nexium approve submitted: " + transactionSignedRequest.Result);
        }
        else
        {
            // if we had an error in the UnityRequest we just display the Exception error
            Debug.Log("Error submitting Nexium approve: " + transactionSignedRequest.Exception.Message);
        }
    }
}