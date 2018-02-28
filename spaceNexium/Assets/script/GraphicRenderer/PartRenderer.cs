using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRenderer : MonoBehaviour
{

    protected GameObject piecePrefab;

    protected string type;

    protected int layerOrder;

    public int id = 0;

    internal Color brightColor = Color.cyan;

    internal Color darkColor = Color.blue;

    internal Color lightColor = Color.white;

    // Use this for initialization
    void Awake()
    {
        piecePrefab = (GameObject)Resources.Load("prefabs/piece");
    }

    protected void InstantiatePiece(Transform parent, string category)
    {
        GameObject piece = Instantiate(piecePrefab, parent);
        piece.GetComponent<PieceRenderer>().setProperties(type, id, category, brightColor, darkColor, lightColor, layerOrder);

    }

}
