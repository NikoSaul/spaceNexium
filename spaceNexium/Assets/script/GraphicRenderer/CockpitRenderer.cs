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

    [SerializeField]
    private GameObject pieceB1;

    [SerializeField]
    private GameObject pieceB2;

    [SerializeField]
    private GameObject pieceB3;

    [SerializeField]
    private GameObject pieceC1;

    [SerializeField]
    private GameObject pieceC2;

    [SerializeField]
    private GameObject pieceC3;

    // Use this for initialization
    void Start () {
        type = "c";

        InstantiatePiece(pieceA1.transform, "0");
        InstantiatePiece(pieceA2.transform, "3");
        InstantiatePiece(pieceA3.transform, "0");

        InstantiatePiece(pieceB1.transform, "1");
        InstantiatePiece(pieceB2.transform, "2");
        InstantiatePiece(pieceB3.transform, "1");

        InstantiatePiece(pieceC1.transform, "1");
        InstantiatePiece(pieceC2.transform, "2");
        InstantiatePiece(pieceC3.transform, "1");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
