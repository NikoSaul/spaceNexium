using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    left,
    middle,
    right
}

public class Weapon : Slot
{
    /// <summary>
    /// La direction où pointe l'arme
    /// </summary>
    public Orientation m_Direction;

    /// <summary>
    /// La position de l'arme sur le vaisseau
    /// </summary>
    public Orientation m_Position;

    public Weapon(SlotType type,PartRenderer sprite, Orientation direction, Orientation position) : base(type, sprite)
    {
        this.m_Direction = direction;
        this.m_Position = position;
    }

    public void Fire(Ship p_Ship_Target)
    {
        //TODO éventuellement déclencher une animation en destination du slot target
    }
}