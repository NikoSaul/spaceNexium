﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorRenderer : PartRenderer {

    [SerializeField]
    private GameObject pieceA1;

    // Use this for initialization
    void Start()
    {
        type = "r";
        layerOrder = 3;
        InstantiatePiece(pieceA1.transform, "0");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
