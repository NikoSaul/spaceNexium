using UnityEngine;
using System.Collections.Generic;

public class BattleTester : MonoBehaviour
{
	public static BattleTester instance { get; private set; }

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
        Ship[] l_LeftShips = new Ship[]
        {
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.laser, null, Orientation.middle, Orientation.middle),
                    new Weapon(SlotType.energy, null, Orientation.right, Orientation.right),
                    new Defense(SlotType.missile, null),
                }
            },
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.energy, null, Orientation.middle, Orientation.left),
                    new Weapon(SlotType.missile, null, Orientation.right, Orientation.middle),
                    new Defense(SlotType.missile, null),
                }
            },
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.laser, null, Orientation.middle, Orientation.middle),
                    new Defense(SlotType.missile, null),
                    new Defense(SlotType.laser, null),
                }
            },
        };

        Ship[] l_RightShips = new Ship[]
        {
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.missile, null, Orientation.right, Orientation.middle),
                    new Weapon(SlotType.missile, null, Orientation.middle, Orientation.left),
                    new Defense(SlotType.energy, null),
                }
            },
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.energy, null, Orientation.right, Orientation.middle),
                    new Defense(SlotType.laser, null),
                    new Defense(SlotType.energy, null),
                }
            },
            new Ship()
            {
                m_Slots = new Slot[]
                {
                    new Weapon(SlotType.energy, null, Orientation.middle, Orientation.right),
                    new Weapon(SlotType.laser, null, Orientation.right, Orientation.middle),
                    new Weapon(SlotType.missile, null, Orientation.middle, Orientation.left),
                }
            },
        };

        BattleManager.instance.InitBattle(l_LeftShips, l_RightShips);
	}
}
