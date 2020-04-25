using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rouge : Units
{
    public Rouge()
    {
        unitType = Types.Rouge;
        //Stats for LVL 1
        damage = 18;
        defens = 5;
        spezialdamage = 15;
        spezialdefens = 5;
        evade = 9;
        speed = 8;

        maxHP = 19;
        currentHP = 19;


    }
}
