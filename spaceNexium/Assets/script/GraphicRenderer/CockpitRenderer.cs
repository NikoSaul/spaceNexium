using System.Collections;
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

        float depthColorCoef = 1.15f;

        brightColor /= depthColorCoef;
        darkColor /= depthColorCoef;
        lightColor /= depthColorCoef;

        brightColor.a = 1;
        darkColor.a = 1;
        lightColor.a = 1;

        InstantiatePiece(pieceA1.transform, "1");
        InstantiatePiece(pieceA2.transform, "0");
        InstantiatePiece(pieceA3.transform, "1");
    }
}
