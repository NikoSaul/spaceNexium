using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitRenderer : PartRenderer {

    [SerializeField]
    private GameObject pieceA1;

    [SerializeField]
    private GameObject pieceA2;

    [SerializeField]
    private GameObject pieceA3;

    // Use this for initialization
    void Start () {
        type = "c";
        layerOrder = 2;

        InstantiatePiece(pieceA1.transform, "1");
        InstantiatePiece(pieceA2.transform, "0");
        InstantiatePiece(pieceA3.transform, "1");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
