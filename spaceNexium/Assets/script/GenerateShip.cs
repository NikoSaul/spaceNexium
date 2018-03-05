using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GenerateShip : MonoBehaviour
{

    private Color[] brightColorsList;
    private Color[] darkColorsList;
    private Color[] lightColorsList;

    [SerializeField]
    private string codeGen;

    private Color brightColor;
    private Color darkColor;
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

    private Ship ship;

    private void Awake()
    {


        initColor();

        GameObject shipPrefab = (GameObject)Resources.Load("prefabs/ShipPattern");
        GameObject shipTemp = Instantiate(shipPrefab, this.transform);
        this.ship = shipTemp.GetComponent<Ship>();
        // - - - - - - - - - - - - - - - - -  Color1 - - - - - - - - - - - - - -
        int lenghtActu = 0; // * * * * Mettre + 24 * * * * (commence à 24)
        int tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;

        brightColor = brightColorsList[tempInt % brightColorsList.Length];

        // - - - - - - - - - - - - - - - - -  Color2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;

        darkColor = darkColorsList[tempInt % darkColorsList.Length];

        // - - - - - - - - - - - - - - - - - lightColor - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        lightColor = lightColorsList[tempInt % lightColorsList.Length];

        this.ship.SetColorGlobal(this.brightColor, this.darkColor, this.lightColor);

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

        this.ship.SetWings(0, wings1);
        // - - - - - - - - - - - - - - - - - Wings 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings2 = tempInt;

        this.ship.SetWings(1, wings2);
        // - - - - - - - - - - - - - - - - - Wings 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings3 = tempInt;

        this.ship.SetWings(2, wings3);
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

    // trois canons
    // 0001010000000000000000000000000000000000000000000000000000000010000000000000000000000000

    // deux canons et un reacteur
    // 0001000001000000000000000000000000000000000000000000000000000011000000000000000000000001 

    // protection 8
    // 0001010000000000000000000000000000000000000000000000000000000010000000000000000010000011

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("space"))
            ImageExporter.SaveScreenshotToFile("test.png");*/

    }

    private void initGamePlay(int i, int id, int design, int orientationOrSubType)
    {
        if (i == 1) // Protection
        {
            this.ship.SetProtections(placement, design, orientationOrSubType);
        }
        else // CANON
        {
            if (id == 0)
                this.ship.SetCanons(id, design, orientationOrSubType);
            else if (id == 1)
            {
                if (placement == 0)
                    this.ship.SetCanons(1, design, orientationOrSubType);
                else if (placement == 1)
                    this.ship.SetCanons(4, design, orientationOrSubType);
                else
                    this.ship.SetCanons(3, design, orientationOrSubType);
            }
            else
            {
                if (placement == 0)
                    this.ship.SetCanons(2, design, orientationOrSubType);
                else if (placement == 1)
                    this.ship.SetCanons(5, design, orientationOrSubType);
                else
                    this.ship.SetCanons(6, design, orientationOrSubType);
            }
        }
    }

    // 
    private void initColor()
    {
        brightColorsList = new Color[10];

        //Common colors
        brightColorsList[0] = new Color(109f / 255f, 109f / 255f, 107f / 255f);
        brightColorsList[1] = new Color(255f / 255f, 176f / 255f, 117f / 255f);
        brightColorsList[2] = new Color(242f / 255f, 225f / 255f, 119f / 255f);
        brightColorsList[3] = new Color(119f / 255f, 242f / 255f, 179f / 255f);
        brightColorsList[4] = new Color(119f / 255f, 162f / 255f, 241f / 255f);
        brightColorsList[5] = new Color(241f / 255f, 118f / 255f, 162f / 255f);

        //Rare colors
        brightColorsList[6] = new Color(209f / 255f, 241f / 255f, 118f / 255f);
        brightColorsList[7] = new Color(116f / 255f, 229f / 255f, 237f / 255f);
        brightColorsList[8] = new Color(226f / 255f, 222f / 255f, 193f / 255f);
        brightColorsList[9] = new Color(254f / 255f, 102f / 255f, 81f / 255f);


        darkColorsList = new Color[10];

        //Common colors
        darkColorsList[0] = new Color(107f / 255f, 37f / 255f, 29f / 255f);
        darkColorsList[1] = new Color(33f / 255f, 40f / 255f, 46f / 255f);
        darkColorsList[2] = new Color(255f / 255f, 145f / 255f, 60f / 255f);
        darkColorsList[3] = new Color(111f / 255f, 95f / 255f, 95f / 255f);
        darkColorsList[4] = new Color(37f / 255f, 119f / 255f, 81f / 255f);
        darkColorsList[5] = new Color(72f / 255f, 97f / 255f, 239f / 255f);

        //Rare colors
        darkColorsList[6] = new Color(239f / 255f, 57f / 255f, 35f / 255f);
        darkColorsList[7] = new Color(255f / 255f, 60f / 255f, 209f / 255f);
        darkColorsList[8] = new Color(255f / 255f, 214f / 255f, 34f / 255f);
        darkColorsList[9] = new Color(255f / 255f, 255f / 255f, 255f / 255f);


        lightColorsList = new Color[10];

        //Common colors
        lightColorsList[0] = new Color(251f / 255f, 255f / 255f, 179f / 255f);
        lightColorsList[1] = new Color(223f / 255f, 255f / 255f, 213f / 255f);
        lightColorsList[2] = new Color(183f / 255f, 255f / 255f, 211f / 255f);
        lightColorsList[3] = new Color(182f / 255f, 193f / 255f, 255f / 255f);
        lightColorsList[4] = new Color(255f / 255f, 221f / 255f, 183f / 255f);
        lightColorsList[5] = new Color(255f / 255f, 183f / 255f, 243f / 255f);

        //Rare colors
        lightColorsList[6] = new Color(255f / 255f, 181f / 255f, 182f / 255f);
        lightColorsList[7] = new Color(255f / 255f, 0f / 255f, 34f / 255f);
        lightColorsList[8] = new Color(255f / 255f, 243f / 255f, 0f / 255f);
        lightColorsList[9] = new Color(0f / 255f, 251f / 255f, 254f / 255f);

    }

}
