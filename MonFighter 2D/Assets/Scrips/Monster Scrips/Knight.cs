using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Knight : Units
{
    public Knight()
    {
        unitType = Types.Knight;
        //Stats for LVL 1
        damage = 9;
        defens = 9;
        spezialdamage = 9;
        spezialdefens = 9;
        evade = 9;
        speed = 9;

        maxHP = 22;
        currentHP = 22;


    }
}
