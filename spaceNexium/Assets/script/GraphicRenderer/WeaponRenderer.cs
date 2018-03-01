using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : PartRenderer
{

    [SerializeField]
    private GameObject pieceA1;

    protected override void CreatePart()
    {
        type = "w";
        layerOrder = 5;
        InstantiatePiece(pieceA1.transform, "0");
    }

}
