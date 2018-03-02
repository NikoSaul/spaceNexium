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
    private Orientation direction;

    /// <summary>
    /// La direction où pointe l'arme
    /// </summary>
    public Orientation m_Direction { get { return direction; } set { direction = value; UpdateDirection(); } }

    /// <summary>
    /// La position de l'arme sur le vaisseau
    /// </summary>
    public Orientation m_Position;
    
    public Weapon(SlotType type,PartRenderer sprite, Orientation direction, Orientation position) : base(type, sprite)
    {
        this.m_Direction = direction;
        this.m_Position = position;
    }

    private void UpdateDirection()
    {
        sprite.RotateSprite(direction);
    }

    public void Fire(Ship p_Ship_Target)
    {
        Debug.Log("Piou");
        //TODO éventuellement déclencher une animation en destination du slot target
        //Je pense qu'il faut balancer une coroutine pour animer un projectile partant de ce canon vers une position aléatoire du vaisseau adverse
    }
}