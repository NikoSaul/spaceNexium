using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRenderer : MonoBehaviour
{

    private string type;

    private int id;

    private string category;

    private int layerPosition;

    public SpriteRenderer lineLayer;

    public SpriteRenderer brightLayer;

    public SpriteRenderer darkLayer;

    public SpriteRenderer lightLayer;

    public SpriteRenderer pipeLayer;
    // Use this for initialization

    void Start()
    {

        Texture2D lineTex = (Texture2D)Resources.Load("sprites/" + type + "/" + id + "/" + category + "/" + type + "_" + id + "_" + category);
        lineLayer.sprite = Sprite.Create(lineTex, new Rect(0, 0, lineTex.width, lineTex.height), new Vector2(0, 0));

        Texture2D brightTex = (Texture2D)Resources.Load("sprites/" + type + "/" + id + "/" + category + "/" + type + "_" + id + "_" + category + "_b");
        brightLayer.sprite = Sprite.Create(brightTex, new Rect(0, 0, lineTex.width, lineTex.height), new Vector2(0, 0));

        Texture2D darkTex = (Texture2D)Resources.Load("sprites/" + type + "/" + id + "/" + category + "/" + type + "_" + id + "_" + category + "_d");
        darkLayer.sprite = Sprite.Create(darkTex, new Rect(0, 0, lineTex.width, lineTex.height), new Vector2(0, 0));

        Texture2D pipeTex = (Texture2D)Resources.Load("sprites/" + type + "/" + id + "/" + category + "/" + type + "_" + id + "_" + category + "_p");
        if (pipeTex != null)
        {
            pipeLayer.sprite = Sprite.Create(pipeTex, new Rect(0, 0, lineTex.width, lineTex.height), new Vector2(0, 0));
        }

        Texture2D lightTex = (Texture2D)Resources.Load("sprites/" + type + "/" + id + "/" + category + "/" + type + "_" + id + "_" + category + "_l");
        if (lightTex != null)
        {
            lightLayer.sprite = Sprite.Create(lightTex, new Rect(0, 0, lineTex.width, lineTex.height), new Vector2(0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void setProperties(string type, int id, string category, Color bright, Color dark, Color light, int layerPosition)
    {
        this.id = id;
        this.type = type;
        this.category = category;

        brightLayer.color = bright;
        darkLayer.color = dark;
        lightLayer.color = light;

        lineLayer.sortingOrder += 5 * layerPosition;
        brightLayer.sortingOrder += 5 * layerPosition;
        darkLayer.sortingOrder += 5 * layerPosition;
        lightLayer.sortingOrder += 5 * layerPosition;
        pipeLayer.sortingOrder += 5 * layerPosition;
    }
}
