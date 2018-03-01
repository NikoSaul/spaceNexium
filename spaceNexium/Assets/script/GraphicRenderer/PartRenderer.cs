using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartRenderer : MonoBehaviour
{

    protected GameObject piecePrefab;

    protected string type;

    protected int layerOrder;

    public int id = 0;

    internal Color brightColor = Color.cyan;

    internal Color darkColor = Color.blue;

    internal Color lightColor = Color.white;


    void Awake()
    {
        piecePrefab = (GameObject)Resources.Load("prefabs/piece");
    }

    /// <summary>
    /// Set the genetic information and create the part
    /// </summary>
    public void SetGeneticAndCreate(int id, Color brightColor, Color darkColor, Color lightColor)
    {
        this.id = id;
        this.brightColor = brightColor;
        this.darkColor = darkColor;
        this.lightColor = lightColor;
        CreatePart();
    }

    protected abstract void CreatePart();

    protected void InstantiatePiece(Transform parent, string category)
    {
        GameObject piece = Instantiate(piecePrefab, parent);
        piece.GetComponent<PieceRenderer>().setProperties(type, id, category, brightColor, darkColor, lightColor, layerOrder);
    }

}
