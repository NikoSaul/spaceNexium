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
        int lenghtActu = 0;
        int tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        color1.r = tempInt * 16;
        color1.g = tempInt * 16;
        color1.b = tempInt * 16;
   
        // - - - - - - - - - - - - - - - - -  Color2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        color2.r = tempInt * 16;
        color2.g = tempInt * 16;
        color2.b = tempInt * 16;

        // - - - - - - - - - - - - - - - - - lightColor - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
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
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        wings1 = tempInt;

        // - - - - - - - - - - - - - - - - - Wings 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        wings2 = tempInt;

        // - - - - - - - - - - - - - - - - - Wings 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        wings3 = tempInt;

        // - - - - - - - - - - - - - - - - - Placement - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        placement = tempInt;

        // - - - - - - - - - - - - - - - - - type 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 1), 2);
        lenghtActu += 1;
        type1 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        orientation1 = tempInt;

        // - - - - - - - - - - - - - - - - - Design 1 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        design1 = tempInt;

        // - - - - - - - - - - - - - - - - - type 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 1), 2);
        lenghtActu += 1;
        type2 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        orientation2 = tempInt;
        
        // - - - - - - - - - - - - - - - - - Design 2 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        design2 = tempInt;

        // - - - - - - - - - - - - - - - - - type 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 1), 2);
        lenghtActu += 1;
        type3 = tempInt;

        // - - - - - - - - - - - - - - - - - orientation 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 2), 2);
        lenghtActu += 2;
        orientation3 = tempInt;

        // - - - - - - - - - - - - - - - - - Design 3 - - - - - - - - - - - - - -
        tempInt = Convert.ToInt32(codeGen.Substring(lenghtActu, 4), 2);
        lenghtActu += 4;
        design3 = tempInt;

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
