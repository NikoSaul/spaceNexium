﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitRenderer : PartRenderer
{

    [SerializeField]
    private GameObject pieceA1;

    [SerializeField]
    private GameObject pieceA2;

    [SerializeField]
    private GameObject pieceA3;

    protected override void CreatePart()
    {
        type = "c";
        layerOrder = 2;

        InstantiatePiece(pieceA1.transform, "1");
        InstantiatePiece(pieceA2.transform, "0");
        InstantiatePiece(pieceA3.transform, "1");
    }
}