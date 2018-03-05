using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingRenderer : PartRenderer
{
    [SerializeField]
    private GameObject pieceA1;

    [SerializeField]
    private GameObject pieceA2;

    [SerializeField]
    private GameObject pieceA3;

    [SerializeField]
    private GameObject pieceA4;

    protected override void CreatePart()
    {
        type = "wi";
        layerOrder = 0;


        float depthColorCoef = 1.3f;

        brightColor /= depthColorCoef;
        darkColor /= depthColorCoef;
        lightColor /= depthColorCoef;

        brightColor.a = 1;
        darkColor.a = 1;
        lightColor.a = 1;


        if (pieceA1 != null)
        {
            InstantiatePiece(pieceA1.transform, "1");
        }

        if (pieceA4 != null)
        {
            InstantiatePiece(pieceA4.transform, "1");
        }

        InstantiatePiece(pieceA2.transform, "0");
        InstantiatePiece(pieceA3.transform, "0");
    }

}
