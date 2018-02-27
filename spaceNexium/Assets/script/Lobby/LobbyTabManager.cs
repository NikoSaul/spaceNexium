using UnityEngine;
using System.Collections.Generic;

public class LobbyTabManager : MonoBehaviour
{
	public static LobbyTabManager instance { get; private set; }
    
	private void Awake()
	{
		instance = this;
	}

    #region First
    

    public void OpenFirstTab()
    {

    }

    public void CloseFirstTab()
    {

    }
    #endregion

    #region Second
    
    public void OpenSecondTab()
    {

    }

    public void CloseSecondTab()
    {

    }
    #endregion

    #region Third

    internal void OpenThirdTab()
    {

    }

    internal void CloseThirdTab()
    {

    }
    #endregion

    #region Fourth

    internal void OpenFourthTab()
    {

    }

    internal void CloseFourthTab()
    {

    }
    #endregion
}
