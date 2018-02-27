using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gene {

    public Color color;
    public Vector2 pos;
    public Sprite sprite;

    // Constructor
    public Gene(Vector2 _pos, Color _color)
    {

        this.pos = _pos; 
        this.color = _color;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
