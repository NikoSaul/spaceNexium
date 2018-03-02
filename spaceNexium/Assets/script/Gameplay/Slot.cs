using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType
{
    laser,      //Pioupiou/bouclier energétique
    missile,    //Lance missile/anti-missiles
    energy,     //Canon à énergie/réacteurs
}

public class Slot
{
    public SlotType m_SlotType;

    protected PartRenderer sprite;

    private static SlotType[] m_aSlotType = (SlotType[])Enum.GetValues(typeof(SlotType));
    private static SlotType[] m_aSlotTypeDoubled = new SlotType[m_aSlotType.Length * 2];
    private static bool m_b_IsInit = false;

    /// <summary>
    /// Returns a list of most effective type (Defense) against the parameter type (Weapon)
    /// </summary>
    public static List<SlotType> GetMostEffective(SlotType p_SlotType)
    {
        if(!m_b_IsInit)
        {
            m_b_IsInit = true;
            m_aSlotType.CopyTo(m_aSlotTypeDoubled, 0);
            m_aSlotType.CopyTo(m_aSlotTypeDoubled, m_aSlotType.Length);
        }

        List<SlotType> l_List_MostEffectiveSlots = new List<SlotType>();
        int l_i_SlotIndex = (int)p_SlotType;
        for(int l_i_Index = 1 ; l_i_Index <= m_aSlotType.Length / 2 ; ++l_i_Index)
        {
            l_List_MostEffectiveSlots.Add(m_aSlotTypeDoubled[l_i_SlotIndex + l_i_Index]);
        }
        return l_List_MostEffectiveSlots;
    }

    /// <summary>
    /// Returns a list of least effective type (Defense) against the parameter type (Weapon)
    /// </summary>
    public static List<SlotType> GetLeastEffective(SlotType p_SlotType)
    {
        List<SlotType> l_List_LeastEffectiveSlots = new List<SlotType>();
        Debug.Log("TODO (GetLeastEffective)");
        return l_List_LeastEffectiveSlots;
    }

    public Slot(SlotType type, PartRenderer sprite)
    {
        this.m_SlotType = type;
        this.sprite = sprite;
    }
}