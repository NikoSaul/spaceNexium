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

    public void setColorGlobal(Color color1, Color color2, Color lightColor)
    {
        this.color1 = color1;
        this.color2 = color2;
        this.lightColor = lightColor;
    }

    public void setCockpit(int i, int id)
    {
        this.cockpits[i].id = id;
        this.cockpits[i].brightColor = this.color1;
        this.cockpits[i].darkColor = this.color2;
        this.cockpits[i].lightColor = this.lightColor;
    }
}
