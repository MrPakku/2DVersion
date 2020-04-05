using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Types
{
    public string Fire;
    public string Water;
    public string Nature;
    public string Air;
    public string ICE;
    public string Time;
    public string Dark;
    public string Light;

    public AttackandEvadecalculation Attack;
    public void TypeCompare(Unit Attacker, Unit Defender)
    {
        switch (Attacker.unitType)
        {
            case "Fire":
                if(Attacker.unitType == "Fire" && Defender.unitType == "Water" || Attacker.unitType == "Fire" && Defender.unitType == "Air")
                {
                    Attacker.damage = Attacker.damage - (Attacker.damage / 4);
                }
                else if (Attacker.unitType == "Fire" && Defender.unitType =="Dark" || Attacker.unitType == "Fire" && Defender.unitType == "Nature")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;

        }

    }

}