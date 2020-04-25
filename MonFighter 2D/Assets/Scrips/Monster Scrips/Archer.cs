using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Archer : Units
{
    public Archer()
    {
        unitType = Types.Archer;
        //Stats for LVL 1
        damage = 19;
        defens = 9;
        spezialdamage = 8;
        spezialdefens = 8;
        evade = 7;
        speed = 7;

        maxHP = 21;
        currentHP = 21;


    }
}
