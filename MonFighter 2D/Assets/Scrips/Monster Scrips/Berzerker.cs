using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Berzerker : Units 
{
    private float HPlost;
    public Berzerker()
    {
        unitType = Types.Berzerker;
        //Stats for LVL 1
        damage = 10;
        defens = 13;
        spezialdamage = 10;
        spezialdefens = 13;
        evade = 3;
        speed = 3;

        maxHP = 27;
        currentHP = 27;
        HPlost = maxHP - currentHP;


    }
    public void Update()
    {
        if (HPlost > 0)
        {
            for (float E = 0; E <= HPlost; E++)
            {
                damage = damage + HPlost;
                spezialdamage = spezialdamage + HPlost;
            }
        }
    }
}
