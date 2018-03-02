using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BattleShip
{
    public Ship m_Ship;

    private bool isActive = true;

    /// <summary>
    /// Le vaisseau est-il encore capable de combattre
    /// </summary>
    public bool m_b_IsActive { get { return isActive; } set { isActive = value; UpdateSprite(); } }

    private bool isDestroyed = false;

    /// <summary>
    /// Le vaisseau est-il réduit en épave
    /// </summary>
    public bool m_b_IsDestroyed { get { return isDestroyed; } set { isDestroyed = value; UpdateSprite(); } }

    /// <summary>
    /// La liste des défenses du vaisseau
    /// </summary>
    public List<Defense> m_List_Defenses = new List<Defense>();

    /// <summary>
    /// La liste des armes du vaisseau
    /// </summary>
    public List<Weapon> m_List_Weapons = new List<Weapon>();

    public BattleShip(Ship p_Ship)
    {
        m_Ship = p_Ship;
    }

    /// <summary>
    /// Met à jour le sprite du vaisseau pour refléter son nouvel état (Actif/Détruit)
    /// </summary>
    private void UpdateSprite()
    {
        Debug.Log("TODO: UpdateSprite BattleShip");
        //m_Ship
    }

    /// <summary>
    /// Une sorte de ToString pour afficher des logs
    /// </summary>
    /// <returns></returns>
    public string GetStatus()
    {
        return string.Format("({0}/{1})", m_b_IsActive, m_b_IsDestroyed);
    }

    /// <summary>
    /// Le vaisseau reçois des dégâts d'une arme, la fonction gère quels défenses vont subir les dégâts et comment ses modules vont tomber ainsi que la destruction du vaisseau
    /// </summary>
    /// <param name="p_Weapon_Source"></param>
    public void ReceiveDamage(Weapon p_Weapon_Source)
    {
        if(m_List_Defenses.Count == 0)
        {
            m_b_IsDestroyed = true;
            m_b_IsActive = false;
            return;
        }

        //On split la liste de défenses en 3 catégories, des plus efficaces aux moins efficaces
        List<SlotType> l_List_MostEffectiveTypes = Slot.GetMostEffective(p_Weapon_Source.m_SlotType);
        List<Defense> l_List_BestDefenses = m_List_Defenses.FindAll(l_Def => l_List_MostEffectiveTypes.Contains(l_Def.m_SlotType));
        Defense l_EquivalentDefense = m_List_Defenses.FirstOrDefault(l_Def => l_Def.m_SlotType == p_Weapon_Source.m_SlotType);
        List<Defense> l_List_WorstDefenses = m_List_Defenses.FindAll(l_Def => l_Def.m_SlotType != p_Weapon_Source.m_SlotType && !l_List_MostEffectiveTypes.Contains(l_Def.m_SlotType));

        //On commence par l'absorption des dégâts par les défenses actives
        int l_i_DamagePower = 3;
        for(int l_i_Index = 0 ; l_i_Index < l_List_BestDefenses.Count ; ++l_i_Index)
        {
            l_i_DamagePower = l_List_BestDefenses[l_i_Index].DefenseAbsorbDamage(l_i_DamagePower, Defense.DefenseResistance.Effective);
        }
        if(l_EquivalentDefense != null)
        {
            l_i_DamagePower = l_EquivalentDefense.DefenseAbsorbDamage(l_i_DamagePower, Defense.DefenseResistance.Neutral);
        }
        for(int l_i_Index = 0 ; l_i_Index < l_List_WorstDefenses.Count ; ++l_i_Index)
        {
            l_i_DamagePower = l_List_WorstDefenses[l_i_Index].DefenseAbsorbDamage(l_i_DamagePower, Defense.DefenseResistance.NonEffective);
        }


        if(l_i_DamagePower > 0)
        //Il reste des points de dégâts
        {
            //On détruit les modules un par un en réduisant les dégâts restant au fur et à mesure
            for(int l_i_Index = 0 ; l_i_Index < l_List_BestDefenses.Count ; ++l_i_Index)
            {
                l_i_DamagePower = l_List_BestDefenses[l_i_Index].TryDestroyModule(l_i_DamagePower);
            }
            if(l_EquivalentDefense != null)
            {
                l_i_DamagePower = l_EquivalentDefense.TryDestroyModule(l_i_DamagePower);
            }
            for(int l_i_Index = 0 ; l_i_Index < l_List_WorstDefenses.Count ; ++l_i_Index)
            {
                l_i_DamagePower = l_List_WorstDefenses[l_i_Index].TryDestroyModule(l_i_DamagePower);
            }

            if(l_i_DamagePower > 0)
            //Il reste encore des points de dégâts
            {
                //On désactive ou détruit le vaisseau
                if(m_b_IsActive)
                    m_b_IsActive = false;
                else
                    m_b_IsDestroyed = true;
            }
        }
    }
}