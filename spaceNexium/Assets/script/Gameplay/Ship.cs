using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    /// <summary>
    /// Les 3 slots de module du vaisseau (arme ou défense)
    /// </summary>
    public Slot[] m_Slots = new Slot[3];

    [SerializeField]
    private PartRenderer[] cockpits;

    [SerializeField]
    private PartRenderer[] canons;

    [SerializeField]
    private PartRenderer[] bases;

    [SerializeField]
    private PartRenderer[] wings;

    [SerializeField]
    private PartRenderer[] protections;

    [SerializeField]
    private PartRenderer[] reactors;

    // COLOR 
    private Color color1;
    private Color color2;
    private Color lightColor;
    private int slotNumber = 0;

    public void SetColorGlobal(Color color1, Color color2, Color lightColor)
    {
        this.color1 = color1;
        this.color2 = color2;
        this.lightColor = lightColor;
    }

    public void SetCockpit(int i, int id)
    {
        this.cockpits[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
    }

    public void SetBases(int i, int id)
    {
        this.bases[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
    }

    public void SetWings(int i, int id)
    {
        this.wings[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
    }


    // - - - - - - - - - - - - - - - - - - GAME PLAY - - - - - - - - - - - - - - - - - - - - - - - - - -
    public void SetCanons(int i, int id, int orientation)
    {
        this.canons[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
        this.m_Slots[slotNumber] = new Slot((SlotType)slotNumber, this.canons[i]);
        slotNumber++;
    }

    public void SetProtections(int i, int id, int subType)
    {
        int tempSlot = Mathf.FloorToInt(id / 4);
        if (subType == 0)
        {
            SetReactors(i % 3, id, subType);
        }
        else
        {
            this.protections[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
            this.m_Slots[slotNumber] = new Slot((SlotType)slotNumber, this.protections[i]);
            slotNumber++;
        }
    }

    // reactor counter energy canon
    public void SetReactors(int i, int id, int subType)
    {
        this.reactors[i].SetGeneticAndCreate(id, this.color1, this.color2, this.lightColor);
        int tempSlot = Mathf.FloorToInt(id / 4);
        this.m_Slots[slotNumber] = new Slot((SlotType)slotNumber, this.reactors[i]);
        slotNumber++;
    }

}
