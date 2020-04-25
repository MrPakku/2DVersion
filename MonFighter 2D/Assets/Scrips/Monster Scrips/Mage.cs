using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mage : Units
{
    public Mage()
    {
        unitType = Types.Mage;
        //Stats for LVL 1
        damage = 3;
        defens = 10;
        spezialdamage = 16;
        spezialdefens = 16;
        evade = 7;
        speed = 7;

        maxHP = 20;
        currentHP = 20;


    }
}
