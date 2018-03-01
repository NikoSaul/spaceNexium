using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GenerateShip : MonoBehaviour
{

    private Color[] colors;
    
    [SerializeField]
    private string codeGen;

    private Color color1;
    private Color color2;
    private Color lightColor;

    private int cockpit;
    private int base1;
    private int base2;
    private int base3;

    private int wings1;
    private int wings2;
    private int wings3;

    private int placement;

    private int design1;
    private int orientationOrSubType1;
    private int type1;

    private int design2;
    private int orientationOrSubType2;
    private int type2;

    private int design3;
    private int orientationOrSubType3;
    private int type3;

    [SerializeField]
    private GameObject shipPrefab;

    private Ship ship;

    private void Awake()
    {
        colors = new Color[6];
        initColor();
        this.ship = this.shipPrefab.GetComponent<Ship>();
        // - - - - - - - - - - - - - - - - -  Color1 - - - - - - - - - - - - - -
        int lenghtActu = 0; // * * * * Mettre + 24 * * * * (commence à 24)
        int tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;

        color1 = colors[tempInt % colors.Length];

        // - - - - - - - - - - - - - - - - -  Color2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;

        color2 = colors[tempInt % colors.Length];

        // - - - - - - - - - - - - - - - - - lightColor - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        lightColor = colors[tempInt % colors.Length];

        this.ship.SetColorGlobal(this.color1, this.color2, this.lightColor);

        // - - - - - - - - - - - - - - - - -  Cockpit - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        cockpit = tempInt;

        this.ship.SetCockpit(0, this.cockpit);

        // - - - - - - - - - - - - - - - - - base 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base1 = tempInt;

        this.ship.SetBases(0, base1);
        // - - - - - - - - - - - - - - - - - base 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base2 = tempInt;

        this.ship.SetBases(1, base2);
        // - - - - - - - - - - - - - - - - - base 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base3 = tempInt;

        this.ship.SetBases(2, base3);
        // - - - - - - - - - - - - - - - - - Wings 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings1 = tempInt;

       // this.ship.SetWings(0, wings1);
        // - - - - - - - - - - - - - - - - - Wings 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings2 = tempInt;

        //this.ship.SetWings(1, wings2);
        // - - - - - - - - - - - - - - - - - Wings 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings3 = tempInt;

        //this.ship.SetWings(2, wings3);
        // - - - - - - - - - - - - - - - - - Placement - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        placement = tempInt;

        // - - - - - - - - - - - - - - - - - - GAME PLAY - - - - - - - - - - - - - - - - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - type 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu + 7, 1), 2);
        type1 = tempInt;

        // - - - - - - - - - - - - - - - - - Design 1 - - - - - - - - - - - - - -
        int tempLenght = 5;
        if (type1 == 1)
            tempLenght = 4;

        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, tempLenght), 2);
        lenghtActu += tempLenght;
        design1 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 1 => CANON - - - - - - - - - - - -
        // - - - - - - -  - - - - -  - - - - subtype => SUBTYPE - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 7 - tempLenght), 2);
        lenghtActu += 7 - tempLenght + 1;
        orientationOrSubType1 = tempInt;

        // - - - - - - - - - - - - - - - - - type 2 - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu + 7, 1), 2);
        type2 = tempInt;

        // - - - - - - - - - - - - - - - - - Design 2 - - - - - - - - - - - - - -
        tempLenght = 5;
        if (type2 == 1)
            tempLenght = 4;

        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, tempLenght), 2);
        lenghtActu += tempLenght;
        design2 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 2 => CANON - - - - - - - - - - - -
        // - - - - - - -  - - - - -  - - - - subtype => SUBTYPE - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 7 - tempLenght), 2);
        lenghtActu += 7 - tempLenght + 1;
        orientationOrSubType2 = tempInt;

        // - - - - - - - - - - - - - - - - - type 3 - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu + 7, 1), 2);
        type3 = tempInt;

        // - - - - - - - - - - - - - - - - - Design 3 - - - - - - - - - - - - - -
        tempLenght = 5;
        if (type3 == 1)
            tempLenght = 4;

        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, tempLenght), 2);
        lenghtActu += tempLenght;
        design3 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 3 => CANON - - - - - - - - - - - -
        // - - - - - - -  - - - - -  - - - - subtype => SUBTYPE - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 7 - tempLenght), 2);
        lenghtActu += 7 - tempLenght + 1;
        orientationOrSubType3 = tempInt;

        // Init Game play - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  - - - - - - - - - - - -
        initGamePlay(type1, 0, design1, orientationOrSubType1);
        initGamePlay(type2, 1, design2, orientationOrSubType2);
        initGamePlay(type3, 2, design3, orientationOrSubType3);
    }

    // Example - - 
    // 00000 11111 00000 11111111 00000000 11111111 00000000 11111 00000 11111 00 11111 00 1 00000 11 0 11111 00 1
    // 0000011111000001111111100000000111111110000000011111000001111100111110010000011011111001
    // 0001010000000000000000000000000000000000000000000000000000000000000000000000000000000000
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void initGamePlay(int i, int id, int design, int orientationOrSubType)
    {
        if (i == 1) // Protection
        {
            this.ship.SetProtections(id, design, orientationOrSubType, this.placement);
        }
        else // CANON
        {
           // if (id == 0)
                this.ship.SetCanons(id, design, orientationOrSubType, this.placement);
           /* else if (id == 1)
            {
                if (placement == 0)
                {

                }
            }*/
        }
    }

    private void initColor()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.magenta;
        colors[4] = Color.yellow;
        colors[5] = Color.cyan;
    }

}
