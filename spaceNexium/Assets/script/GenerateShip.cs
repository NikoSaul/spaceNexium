using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateShip : MonoBehaviour {

    [SerializeField]
    private GameObject moduleBase;

    public string geneticCode;

    private void Awake()
    {
        string[] genes = geneticCode.Split(' ');
    
        for (int i = 0; i < genes.Length; i+=3) {

            
        }
    }

    // Use this for initialization
    void Start () {
		

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
