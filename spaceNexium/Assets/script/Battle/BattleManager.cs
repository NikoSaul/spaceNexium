using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

public class BattleManager : MonoBehaviour
{
	public static BattleManager instance { get; private set; }
    
    private BattleShip[] m_LeftPlayerFleet = new BattleShip[3];
    private BattleShip[] m_RightPlayerFleet = new BattleShip[3];

    private void Awake()
	{
		instance = this;
	}

    /// <summary>
    /// Inits a battle and starts it with a coroutine
    /// </summary>
    /// <param name="p_LeftPlayerFleet"></param>
    /// <param name="p_RightPlayerFleet"></param>
    public void InitBattle(Ship[] p_LeftPlayerFleet, Ship[] p_RightPlayerFleet)
    {
        Ship l_Ship;
        for(int l_i_Index = 0 ; l_i_Index < p_LeftPlayerFleet.Length ; ++l_i_Index)
        {
            //Left player
            l_Ship = p_LeftPlayerFleet[l_i_Index];
            m_LeftPlayerFleet[l_i_Index] = new BattleShip(l_Ship);

            for(int l_i_IndexSlots = 0 ; l_i_IndexSlots < l_Ship.m_Slots.Length ; ++l_i_IndexSlots)
            {
                if(l_Ship.m_Slots[l_i_IndexSlots] is Weapon)
                {
                    m_LeftPlayerFleet[l_i_Index].m_List_Weapons.Add(l_Ship.m_Slots[l_i_IndexSlots] as Weapon);
                }
                else if(l_Ship.m_Slots[l_i_IndexSlots] is Defense)
                {
                    m_LeftPlayerFleet[l_i_Index].m_List_Defenses.Add(l_Ship.m_Slots[l_i_IndexSlots] as Defense);
                }
            }
            
            //Right player
            l_Ship = p_RightPlayerFleet[l_i_Index];
            m_RightPlayerFleet[l_i_Index] = new BattleShip(l_Ship);

            for(int l_i_IndexSlots = 0 ; l_i_IndexSlots < l_Ship.m_Slots.Length ; ++l_i_IndexSlots)
            {
                if(l_Ship.m_Slots[l_i_IndexSlots] is Weapon)
                {
                    m_RightPlayerFleet[l_i_Index].m_List_Weapons.Add(l_Ship.m_Slots[l_i_IndexSlots] as Weapon);
                }
                else if(l_Ship.m_Slots[l_i_IndexSlots] is Defense)
                {
                    m_RightPlayerFleet[l_i_Index].m_List_Defenses.Add(l_Ship.m_Slots[l_i_IndexSlots] as Defense);
                }
            }
        }
        
        //Start the battle
        StartCoroutine(BattleTurn());
    }
    
    private enum BattleWinner
    {
        NotResolved,
        LeftPlayer,
        RightPlayer,
        Draw
    }

    /// <summary>
    /// La fonction "Update" gérant le cours de la bataille entre 2 joueurs
    /// </summary>
    /// <returns></returns>
    private IEnumerator BattleTurn()
    {
        //Queue pour préparer la liste des actions des canons à chaque tours
        Queue<Action> l_Queue_WeaponsActions = new Queue<Action>();
        bool l_b_Resolved = false;
        BattleWinner l_BattleWinner = BattleWinner.NotResolved;
        int l_i_NbTurn = 0;

        while(!l_b_Resolved)
        {
            ++l_i_NbTurn;

            #region RechargeDesDefenses
            for(int l_i_Index = 0 ; l_i_Index < m_LeftPlayerFleet.Length ; ++l_i_Index)
            {
                for(int l_i_DefenseIndex = 0 ; l_i_DefenseIndex < m_LeftPlayerFleet[l_i_Index].m_List_Defenses.Count ; ++l_i_DefenseIndex)
                {
                    m_LeftPlayerFleet[l_i_Index].m_List_Defenses[l_i_DefenseIndex].RechargeDefense();
                }
                for(int l_i_DefenseIndex = 0 ; l_i_DefenseIndex < m_RightPlayerFleet[l_i_Index].m_List_Defenses.Count ; ++l_i_DefenseIndex)
                {
                    m_RightPlayerFleet[l_i_Index].m_List_Defenses[l_i_DefenseIndex].RechargeDefense();
                }
            }
            #endregion

            #region Repositionnement
            for(int l_i_Index = 1 ; l_i_Index < m_LeftPlayerFleet.Length ; ++l_i_Index)
            //Joueur gauche
            {
                if(!m_LeftPlayerFleet[l_i_Index].m_b_IsDestroyed)
                //Le vaisseau n'est pas détruit
                {
                    int l_i_ReposiIndex = l_i_Index;
                    while(l_i_ReposiIndex > 0 && m_LeftPlayerFleet[l_i_ReposiIndex - 1].m_b_IsDestroyed)
                    //Swap des deux vaisseaux si celui de gauche est détruit
                    {
                        BattleShip l_BS_Temp = m_LeftPlayerFleet[l_i_ReposiIndex - 1];
                        m_LeftPlayerFleet[l_i_ReposiIndex - 1] = m_LeftPlayerFleet[l_i_ReposiIndex];
                        m_LeftPlayerFleet[l_i_ReposiIndex] = l_BS_Temp;
                        --l_i_ReposiIndex;
                    }
                }
            }

            for(int l_i_Index = 0 ; l_i_Index < m_RightPlayerFleet.Length ; ++l_i_Index)
            //Joueur droite
            {
                if(!m_RightPlayerFleet[l_i_Index].m_b_IsDestroyed)
                //Le vaisseau n'est pas détruit
                {
                    int l_i_ReposiIndex = l_i_Index;
                    while(l_i_ReposiIndex > 0 && m_RightPlayerFleet[l_i_ReposiIndex - 1].m_b_IsDestroyed)
                    //Swap des deux vaisseaux si celui de gauche est détruit
                    {
                        BattleShip l_BS_Temp = m_RightPlayerFleet[l_i_ReposiIndex - 1];
                        m_RightPlayerFleet[l_i_ReposiIndex - 1] = m_RightPlayerFleet[l_i_ReposiIndex];
                        m_RightPlayerFleet[l_i_ReposiIndex] = l_BS_Temp;
                        --l_i_ReposiIndex;
                    }
                }
            }
            #endregion

            #region ActionsJoueurGauche
            for(int l_i_Index = 0 ; l_i_Index < m_LeftPlayerFleet.Length ; ++l_i_Index)
            //Gestion des tirs de chaque vaisseaux actifs du joueur GAUCHE
            {
                if(m_LeftPlayerFleet[l_i_Index].m_b_IsActive)
                //Le vaisseau est actif et peut potentiellement tirer
                {
                    //On parcours tous les canons et on trouve les cibles correspondantes
                    for(int l_i_IndexWeapons = 0 ; l_i_IndexWeapons < m_LeftPlayerFleet[l_i_Index].m_List_Weapons.Count ; ++l_i_IndexWeapons)
                    {
                        Weapon l_CurrentWeapon = m_LeftPlayerFleet[l_i_Index].m_List_Weapons[l_i_IndexWeapons];
                        int l_i_TargetPosition = -1;
                        switch(l_CurrentWeapon.m_Direction)
                        {
                            case Orientation.left:
                                //Tir à gauche !
                                l_i_TargetPosition = l_i_Index - 1;
                                break;
                            case Orientation.middle:
                                //Tir en face !
                                l_i_TargetPosition = l_i_Index;
                                break;
                            case Orientation.right:
                                //Tir à droite !
                                l_i_TargetPosition = l_i_Index + 1;
                                break;
                        }

                        if(l_i_TargetPosition < 0 || l_i_TargetPosition >= m_RightPlayerFleet.Length || m_RightPlayerFleet[l_i_TargetPosition].m_b_IsDestroyed)
                        //Pas de tir possible
                        {
                            //On tente une réorientation, sinon on passe le tour
                            switch(l_CurrentWeapon.m_Position)
                            {
                                case Orientation.left:
                                    if(l_CurrentWeapon.m_Direction == Orientation.left)
                                    //à gauche
                                    {
                                        //On vérif si on a une cible en face
                                        if(!m_RightPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    else
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à gauche
                                        if(l_i_Index >= 1 && !m_RightPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                    }
                                    break;
                                case Orientation.middle:
                                    if(l_CurrentWeapon.m_Direction == Orientation.left)
                                    //à gauche
                                    {
                                        //On vérif si on a une cible en face ou à droite
                                        if(!m_RightPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                        else if(l_i_Index + 1 < m_RightPlayerFleet.Length && !m_RightPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else if(l_CurrentWeapon.m_Direction == Orientation.middle)
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à gauche ou à droite
                                        if(l_i_Index >= 1 && !m_RightPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                        else if(l_i_Index + 1 < m_RightPlayerFleet.Length && !m_RightPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else
                                    //à droite
                                    {
                                        //On vérif si on a une cible à gauche ou en face
                                        if(l_i_Index >= 1 && !m_RightPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                        else if(!m_RightPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    break;
                                case Orientation.right:
                                    if(l_CurrentWeapon.m_Direction == Orientation.middle)
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à droite
                                        if(l_i_Index + 1 < m_RightPlayerFleet.Length && !m_RightPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else
                                    //à droite
                                    {
                                        //On vérif si on a une cible en face
                                        if(!m_RightPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        //On peut tirer
                        {
                            int l_i_LogIndex0 = l_i_NbTurn;
                            int l_i_LogIndex1 = l_i_Index;
                            int l_i_LogIndex2 = l_i_IndexWeapons;
                            int l_i_LogIndex3 = l_i_TargetPosition;
                            l_Queue_WeaponsActions.Enqueue(() =>
                            {
                                m_RightPlayerFleet[l_i_TargetPosition].ReceiveDamage(l_CurrentWeapon);
                                l_CurrentWeapon.Fire(m_RightPlayerFleet[l_i_TargetPosition].m_Ship);
                                Debug.Log("Turn " + l_i_LogIndex0 + ": Left ship " + l_i_LogIndex1 + " shoots with weapon " + l_i_LogIndex2 + " on Right ship " + l_i_LogIndex3);
                            });
                        }
                    }
                }
            }
            #endregion
            #region ActionsJoueurDroit
            for(int l_i_Index = 0 ; l_i_Index < m_RightPlayerFleet.Length ; ++l_i_Index)
            //Gestion des tirs de chaque vaisseaux actifs du joueur DROITE
            {
                if(m_RightPlayerFleet[l_i_Index].m_b_IsActive)
                //Le vaisseau est actif et peut potentiellement tirer
                {
                    //On parcours tous les canons et on trouve les cibles correspondantes
                    for(int l_i_IndexWeapons = 0 ; l_i_IndexWeapons < m_RightPlayerFleet[l_i_Index].m_List_Weapons.Count ; ++l_i_IndexWeapons)
                    {
                        Weapon l_CurrentWeapon = m_RightPlayerFleet[l_i_Index].m_List_Weapons[l_i_IndexWeapons];
                        int l_i_TargetPosition = -1;
                        switch(l_CurrentWeapon.m_Direction)
                        {
                            case Orientation.left:
                                //Tir à gauche !
                                l_i_TargetPosition = l_i_Index + 1;
                                break;
                            case Orientation.middle:
                                //Tir en face !
                                l_i_TargetPosition = l_i_Index;
                                break;
                            case Orientation.right:
                                //Tir à droite !
                                l_i_TargetPosition = l_i_Index - 1;
                                break;
                        }

                        if(l_i_TargetPosition < 0 || l_i_TargetPosition >= m_LeftPlayerFleet.Length || m_LeftPlayerFleet[l_i_TargetPosition].m_b_IsDestroyed)
                        //Pas de tir possible
                        {
                            //On tente une réorientation, sinon on passe le tour
                            switch(l_CurrentWeapon.m_Position)
                            {
                                case Orientation.left:
                                    if(l_CurrentWeapon.m_Direction == Orientation.left)
                                    //à gauche
                                    {
                                        //On vérif si on a une cible en face
                                        if(!m_LeftPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    else
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à gauche
                                        if(l_i_Index + 1 < m_LeftPlayerFleet.Length && !m_LeftPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                    }
                                    break;
                                case Orientation.middle:
                                    if(l_CurrentWeapon.m_Direction == Orientation.left)
                                    //à gauche
                                    {
                                        //On vérif si on a une cible en face ou à droite
                                        if(!m_LeftPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                        else if(l_i_Index >= 1 && !m_LeftPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else if(l_CurrentWeapon.m_Direction == Orientation.middle)
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à gauche ou à droite
                                        if(l_i_Index + 1 < m_LeftPlayerFleet.Length && !m_LeftPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                        else if(l_i_Index >= 1 && !m_LeftPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else
                                    //à droite
                                    {
                                        //On vérif si on a une cible à gauche ou en face
                                        if(l_i_Index + 1 < m_LeftPlayerFleet.Length && !m_LeftPlayerFleet[l_i_Index + 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.left;
                                            });
                                        }
                                        else if(!m_LeftPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    break;
                                case Orientation.right:
                                    if(l_CurrentWeapon.m_Direction == Orientation.middle)
                                    //Tout droit
                                    {
                                        //On vérif si on a une cible à droite
                                        if(l_i_Index >= 1 && !m_LeftPlayerFleet[l_i_Index - 1].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.right;
                                            });
                                        }
                                    }
                                    else
                                    //à droite
                                    {
                                        //On vérif si on a une cible en face
                                        if(!m_LeftPlayerFleet[l_i_Index].m_b_IsDestroyed)
                                        {
                                            l_Queue_WeaponsActions.Enqueue(() =>
                                            {
                                                l_CurrentWeapon.m_Direction = Orientation.middle;
                                            });
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        //On peut tirer
                        {
                            int l_i_LogIndex0 = l_i_NbTurn;
                            int l_i_LogIndex1 = l_i_Index;
                            int l_i_LogIndex2 = l_i_IndexWeapons;
                            int l_i_LogIndex3 = l_i_TargetPosition;
                            l_Queue_WeaponsActions.Enqueue(() =>
                            {
                                m_LeftPlayerFleet[l_i_TargetPosition].ReceiveDamage(l_CurrentWeapon);
                                l_CurrentWeapon.Fire(m_LeftPlayerFleet[l_i_TargetPosition].m_Ship);
                                Debug.Log("Turn " + l_i_LogIndex0 + ": Right ship " + l_i_LogIndex1 + " shoots with weapon " + l_i_LogIndex2 + " on Left ship " + l_i_LogIndex3);
                            });
                        }
                    }
                }
            }
            #endregion

            //On vide la queue pour faire toutes les actions
            while(l_Queue_WeaponsActions.Count > 0)
            {
                l_Queue_WeaponsActions.Dequeue()();
            }

            bool l_b_LeftOneActive = false;
            for(int l_i_Index = 0 ; l_i_Index < m_LeftPlayerFleet.Length ; ++l_i_Index)
            {
                if(m_LeftPlayerFleet[l_i_Index].m_b_IsActive)
                    l_b_LeftOneActive = true;
            }
            bool l_b_RightOneActive = false;
            for(int l_i_Index = 0 ; l_i_Index < m_RightPlayerFleet.Length ; ++l_i_Index)
            {
                if(m_RightPlayerFleet[l_i_Index].m_b_IsActive)
                    l_b_RightOneActive = true;
            }

            if(l_BattleWinner != BattleWinner.NotResolved)
            {
                l_b_Resolved = true;
            }
            else
            {
                if(!l_b_LeftOneActive)
                {
                    if(!l_b_RightOneActive)
                    {
                        l_BattleWinner = BattleWinner.Draw;
                        l_b_Resolved = true;
                    }
                    else
                        l_BattleWinner = BattleWinner.RightPlayer;
                }
                else
                {
                    if(!l_b_RightOneActive)
                        l_BattleWinner = BattleWinner.LeftPlayer;
                }
            }

            Debug.Log(string.Format("BattleStatus : {0},{1},{2} ; {3},{4},{5}", m_LeftPlayerFleet[0].GetStatus(), m_LeftPlayerFleet[1].GetStatus(), m_LeftPlayerFleet[2].GetStatus(), m_RightPlayerFleet[0].GetStatus(), m_RightPlayerFleet[1].GetStatus(), m_RightPlayerFleet[2].GetStatus()));

            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("Battle winner: " + l_BattleWinner.ToString() + " in " + l_i_NbTurn + " turns.");
    }
}