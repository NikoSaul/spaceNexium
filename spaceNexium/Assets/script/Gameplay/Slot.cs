using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType
{
    missile,
    energy,
    laser
}

public class Slot : MonoBehaviour {

    private SlotType type;

    private PartRenderer sprite;

    public Slot(SlotType type, PartRenderer sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
