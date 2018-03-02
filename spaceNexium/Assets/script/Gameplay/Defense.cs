using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : Slot
{
    private bool isDefenseUp = true;
    /// <summary>
    /// L'état de la défense : si active, la prochaine attaque sera absorbée en fonction de l'efficacité de la défense.
    /// Si non active, le module absorbera un point de dégât et sera détruit.
    /// </summary>
    private bool m_b_IsDefenseUp { get { return isDefenseUp; } set { isDefenseUp = value; UpdateSprite(); } }

    private bool isDestroyed = false;
    /// <summary>
    /// L'état du module, si détruit il n'est plus utilisable, sinon il peut de lui même absorber 1 point de dégât
    /// </summary>
    private bool m_b_IsDestroyed { get { return isDestroyed; } set { isDestroyed = value; UpdateSprite(); } }

    private bool m_b_RecentlyDown = false;

    public Defense(SlotType type, PartRenderer sprite): base(type, sprite)
    {
    }

    public enum DefenseResistance
    {
        NonEffective = 1,
        Neutral,
        Effective,
    }

    /// <summary>
    /// Met à jour le sprite de la défense pour refléter son nouvel état (Defense active / Module détruit)
    /// </summary>
    private void UpdateSprite()
    {
        Debug.Log("TODO: UpdateSprite Defense");
    }

    /// <summary>
    /// Absorbe des dégâts provenant d'une attaque et retourne les dégâts restant, désactive la défense
    /// </summary>
    public int DefenseAbsorbDamage(int p_i_AttackPower, DefenseResistance p_DefenseResistance)
    {
        if(m_b_IsDestroyed)
            return p_i_AttackPower;

        if(p_i_AttackPower > 0 && m_b_IsDefenseUp)
        //Défense active, on la perd en diminuant la puissance de l'attaque
        {
            p_i_AttackPower -= (int)p_DefenseResistance;
            m_b_IsDefenseUp = false;
            m_b_RecentlyDown = true;
        }
        return p_i_AttackPower;
    }

    /// <summary>
    /// Le module absorbe un point de dégât et est ensuite détruit, retourne les dégâts restants
    /// </summary>
    public int TryDestroyModule(int p_i_AttackPower)
    {
        if(m_b_IsDestroyed)
            return p_i_AttackPower;
        
        if(p_i_AttackPower > 0)
        //Défense inactive, on perd notre module en réduisant la puissance de l'attaque
        {
            --p_i_AttackPower;
            m_b_IsDestroyed = true;
        }
        return p_i_AttackPower;
    }

    /// <summary>
    /// Recharge la défense si elle est tombé il y a 2 tours
    /// </summary>
    public void RechargeDefense()
    {
        if(m_b_IsDestroyed)
            return;

        //On laisse un tour de battement
        if(!m_b_RecentlyDown)
            m_b_IsDefenseUp = true;

        m_b_RecentlyDown = false;
    }
}