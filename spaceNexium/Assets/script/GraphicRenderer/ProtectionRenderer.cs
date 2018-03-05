using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionRenderer : PartRenderer
{
    [SerializeField]
    private GameObject pieceA1;

    protected override void CreatePart()
    {
        type = "p";
        layerOrder = 4;

        InstantiatePiece(pieceA1.transform, "0");
    }
}
