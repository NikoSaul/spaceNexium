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

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
