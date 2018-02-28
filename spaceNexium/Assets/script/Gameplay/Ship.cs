using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    private Slot[] slots = new Slot[3];

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

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColorGlobal(Color color1, Color color2, Color lightColor)
    {
        this.color1 = color1;
        this.color2 = color2;
        this.lightColor = lightColor;
    }

    public void SetCockpit(int i, int id)
    {
        this.cockpits[i].id = id;
        this.cockpits[i].brightColor = this.color1;
        this.cockpits[i].darkColor = this.color2;
        this.cockpits[i].lightColor = this.lightColor;
    }



    public void SetBases(int i, int id)
    {
        this.bases[i].id = id;
        this.bases[i].brightColor = this.color1;
        this.bases[i].darkColor = this.color2;
        this.bases[i].lightColor = this.lightColor;
    }

    public void SetWings(int i, int id)
    {
        this.wings[i].id = id;
        this.wings[i].brightColor = this.color1;
        this.wings[i].darkColor = this.color2;
        this.wings[i].lightColor = this.lightColor;
    }


    // - - - - - - - - - - - - - - - - - - GAME PLAY - - - - - - - - - - - - - - - - - - - - - - - - - -
    public void SetCanons(int i, int id, int orientation, int placement)
    {
        this.canons[i].id = id;
        this.canons[i].brightColor = this.color1;
        this.canons[i].darkColor = this.color2;
        this.canons[i].lightColor = this.lightColor;
        int tempSlot = Mathf.FloorToInt(id / 4);
        this.slots[i] = new Slot((SlotType)tempSlot, this.canons[i]);
    }

    public void SetProtections(int i, int id, int subType, int placement)
    {
        int tempSlot = Mathf.FloorToInt(id / 4);
        if (tempSlot < 4)
        {
            SetReactors(i, id, subType, placement);
        } else
        {
            this.protections[i].id = id;
            this.protections[i].brightColor = this.color1;
            this.protections[i].darkColor = this.color2;
            this.protections[i].lightColor = this.lightColor;
            this.slots[i] = new Slot((SlotType)tempSlot, this.protections[i]);
        }
    }

    // reactor counter energy canon
    public void SetReactors(int i, int id, int subType, int placement)
    {
        this.reactors[i].id = id;
        this.reactors[i].brightColor = this.color1;
        this.reactors[i].darkColor = this.color2;
        this.reactors[i].lightColor = this.lightColor;
        int tempSlot = Mathf.FloorToInt(id / 4);
        this.slots[i] = new Slot((SlotType)tempSlot, this.reactors[i]);
    }

}
