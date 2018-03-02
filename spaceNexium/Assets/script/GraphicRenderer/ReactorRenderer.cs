using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorRenderer : PartRenderer
{

    [SerializeField]
    private GameObject pieceA1;

    [SerializeField]
    private GameObject pieceA2;

    protected override void CreatePart()
    {
        type = "r";
        layerOrder = 3;
        InstantiatePiece(pieceA1.transform, "0");
        InstantiatePiece(pieceA2.transform, "0");
    }
}
