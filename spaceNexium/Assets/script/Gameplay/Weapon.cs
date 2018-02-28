using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    left,
    midlle,
    right
}


public class Weapon : Slot
{

    private Orientation direction;
    private Orientation position;

    public Weapon(SlotType type,PartRenderer sprite, Orientation direction, Orientation position) : base(type,sprite)
    {
        this.direction = direction;
        this.position = position;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
