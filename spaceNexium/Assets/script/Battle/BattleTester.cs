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
        /* Left Player */
        Ship[] l_LeftShips = new Ship[3];

        GameObject l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(-5, 4, 0),
            Quaternion.Euler(0, 0, -90)
            );
        GenerateShip l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_LeftShips[0] = l_GenShip.GetShip();

        l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(-5, 0, 0),
            Quaternion.Euler(0, 0, -90)
            );
        l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_LeftShips[1] = l_GenShip.GetShip();

        l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(-5, -4, 0),
            Quaternion.Euler(0, 0, -90)
            );
        l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_LeftShips[2] = l_GenShip.GetShip();

        /* Right Player */
        Ship[] l_RightShips = new Ship[3];

        l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(5, 4, 0),
            Quaternion.Euler(0, 0, 90)
            );
        l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_RightShips[0] = l_GenShip.GetShip();

        l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(5, 0, 0),
            Quaternion.Euler(0, 0, 90)
            );
        l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_RightShips[1] = l_GenShip.GetShip();

        l_GO_TempShip = new GameObject("Ship");
        l_GO_TempShip.transform.SetPositionAndRotation
            (
            new Vector3(5, -4, 0),
            Quaternion.Euler(0, 0, 90)
            );
        l_GenShip = l_GO_TempShip.AddComponent<GenerateShip>();
        l_GenShip.SetCodeGen("0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001");
        l_RightShips[2] = l_GenShip.GetShip();

        /*{
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
        };*/

        BattleManager.instance.InitBattle(l_LeftShips, l_RightShips);
	}
}
