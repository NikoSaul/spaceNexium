using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartRenderer : MonoBehaviour
{

    private List<PieceRenderer> pieces;

    protected GameObject piecePrefab;

    protected string type;

    protected int layerOrder;

    internal int id = 0;

    internal Color brightColor = Color.cyan;

    internal Color darkColor = Color.blue;

    internal Color lightColor = Color.white;

    /// <summary>
    /// Set the genetic information and create the part
    /// </summary>
    public void SetGeneticAndCreate(int id, Color brightColor, Color darkColor, Color lightColor)
    {
        this.pieces = new List<PieceRenderer>();
        this.id = id;
        this.brightColor = brightColor;
        this.darkColor = darkColor;
        this.lightColor = lightColor;
        CreatePart();
    }

    protected abstract void CreatePart();

    public void DeactivatePart()
    {
        foreach(PieceRenderer p in pieces)
        {
            p.changeAllLayersColor(Color.gray);
        }
    }

    protected void InstantiatePiece(Transform parent, string category)
    {
        piecePrefab = (GameObject)Resources.Load("prefabs/piece");
        GameObject piece = Instantiate(piecePrefab, parent);
        PieceRenderer pieceTmp = piece.GetComponent<PieceRenderer>();
        pieceTmp.setProperties(type, id, category, brightColor, darkColor, lightColor, layerOrder);
        pieces.Add(pieceTmp);

    }

    public void RotateSprite(Orientation p_Orientation)
    {
        switch(p_Orientation)
        {
            case Orientation.left:
                transform.localRotation = Quaternion.Euler(0, 0, -45);
                break;
            case Orientation.middle:
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
            case Orientation.right:
                transform.localRotation = Quaternion.Euler(0, 0, 45);
                break;
        }
    }
}
