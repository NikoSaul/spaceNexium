using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class GenerateShip : MonoBehaviour
{

    [SerializeField]
    private GameObject moduleBase;

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
    private int orientation1;
    private int type1;

    private int design2;
    private int orientation2;
    private int type2;

    private int design3;
    private int orientation3;
    private int type3;

    private void Awake()
    {
        // - - - - - - - - - - - - - - - - -  Color1 - - - - - - - - - - - - - -
        int lenghtActu = 0; // * * * * Mettre + 24 * * * * (commence à 24)
        int tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        color1.r = tempInt * 32;
        color1.g = tempInt * 32;
        color1.b = tempInt * 32;

        // - - - - - - - - - - - - - - - - -  Color2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        color2.r = tempInt * 16;
        color2.g = tempInt * 16;
        color2.b = tempInt * 16;

        // - - - - - - - - - - - - - - - - - lightColor - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        lightColor.r = tempInt * 16;
        lightColor.g = tempInt * 16;
        lightColor.b = tempInt * 16;

        // - - - - - - - - - - - - - - - - -  Cockpit - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        cockpit = tempInt;

        // - - - - - - - - - - - - - - - - - base 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base1 = tempInt;
        // - - - - - - - - - - - - - - - - - base 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base2 = tempInt;

        // - - - - - - - - - - - - - - - - - base 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 8), 2);
        lenghtActu += 8;
        base3 = tempInt;

        // - - - - - - - - - - - - - - - - - Wings 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings1 = tempInt;

        // - - - - - - - - - - - - - - - - - Wings 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings2 = tempInt;

        // - - - - - - - - - - - - - - - - - Wings 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 5), 2);
        lenghtActu += 5;
        wings3 = tempInt;

        // - - - - - - - - - - - - - - - - - Placement - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        placement = tempInt;

        // - - - - - - - - - - - - - - - - - - GAME PLAY - - - - - - - - - - - - - - - - - - - - - - - - - -
        // 64 

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
        orientation1 = tempInt;

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
        orientation2 = tempInt;

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
        orientation3 = tempInt;
    }

    // 00000 11111 00000 11111111 00000000 11111111 00000000 11111 00000 11111 00 11111 00 1 00000 11 0 11111 00 1
    // 0000011111000001111111100000000111111110000000011111000001111100111110010000011011111001
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

}
