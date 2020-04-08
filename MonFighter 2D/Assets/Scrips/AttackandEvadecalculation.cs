using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackandEvadecalculation : MonoBehaviour
{
    public Unit playerUnit;
    public Unit enemyunit;
    public BattleSystem Battle;

    public bool Hit;
    public bool frozen;


    public void normalEvadeCheck(Unit Attcker, Unit Defender)
    {
        float Rdm;
        float DefTrueEvade;
        float AttackChance;
        float HitChance;
        float FrezzChance;

        HitChance = 100;
        Rdm = Random.Range(0, 100);
        DefTrueEvade = (Defender.evade - Attcker.evade) /10;
        AttackChance = Random.Range(0, HitChance);

        if (HitChance <  Rdm)
        {
            Battle.dialogueText.text = Attcker.unitName + " missed the attack";
            Hit = false;
        }
        else if(DefTrueEvade >= Rdm)
        {
            Battle.dialogueText.text = Defender.unitName + " dodged your attack.";
            Hit = false;
        }
        else
        {
            FrezzChance = (HitChance / 100) *2;
            if (FrezzChance >= Random.Range(0, 100) && Attcker.unitType == "ICE")
            {
                frozen = true;
                return;
            }
            Hit = true;
        }

    }

    public void elemetEvadeCheck(Unit Attacker, Unit Defender)
    {
        TypeCompare(Attacker, Defender);
        normalEvadeCheck(Attacker, Defender);
    }

    public void TypeCompare(Unit Attacker, Unit Defender)
    {
        switch (Attacker.unitType)
        {
            case "Fire":
                if (Attacker.unitType == "Fire" && Defender.unitType == "Water" || Attacker.unitType == "Fire" && Defender.unitType == "Air")
                {
                    Attacker.damage = Attacker.damage - (Attacker.damage / 4);
                }
                else if (Attacker.unitType == "Fire" && Defender.unitType == "Nature" || Attacker.unitType == "Fire" && Defender.unitType == "Dark")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Water":
                if (Attacker.unitType == "Water" && Defender.unitType == "Nature" || Attacker.unitType == "Water" && Defender.unitType == "Light")
                {
                    Attacker.damage = Attacker.damage - ((Attacker.damage / 100) * 5);
                    Attacker.defens = Attacker.defens - ((Attacker.defens / 100) * 5);
                    Attacker.speed = Attacker.speed - ((Attacker.speed / 100) * 5);
                    Attacker.evade = Attacker.evade - ((Attacker.evade / 100) * 5);
                    Attacker.elementdamage = Attacker.elementdamage - ((Attacker.elementdamage / 100) * 5);
                    Attacker.elemetdefens = Attacker.elemetdefens - ((Attacker.elemetdefens / 100) * 5);
                }
                else if (Attacker.unitType == "Water" && Defender.unitType == "Fire" || Attacker.unitType == "Water" && Defender.unitType == "ICE")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Nature":
                if (Attacker.unitType == "Nature" && Defender.unitType == "Fire" || Attacker.unitType == "Nature" && Defender.unitType == "Dark")
                {
                    Attacker.defens = Attacker.defens - (Attacker.defens / 4);
                }
                else if (Attacker.unitType == "Nature" && Defender.unitType == "Water" || Attacker.unitType == "Nature" && Defender.unitType == "Air")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Air":
                if (Attacker.unitType == "Air" && Defender.unitType == "Time" || Attacker.unitType == "Air" && Defender.unitType == "Nature")
                {
                    Attacker.speed = Attacker.speed - (Attacker.speed / 4);
                }
                else if (Attacker.unitType == "Air" && Defender.unitType == "Fire" || Attacker.unitType == "Air" && Defender.unitType == "ICE")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Light":
                if (Attacker.unitType == "Light" && Defender.unitType == "Time" || Attacker.unitType == "Light" && Defender.unitType == "ICE")
                {
                    Attacker.evade = Attacker.evade / 2;
                }
                else if (Attacker.unitType == "Light" && Defender.unitType == "Dark" || Attacker.unitType == "Light" && Defender.unitType == "Water")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Dark":
                if (Attacker.unitType == "Dark" && Defender.unitType == "Light" || Attacker.unitType == "Dark" && Defender.unitType == "Fire")
                {
                    Attacker.elemetdefens= Attacker.elemetdefens - (Attacker.elemetdefens / 4);
                }
                else if (Attacker.unitType == "Dark" && Defender.unitType == "Time" || Attacker.unitType == "Dark" && Defender.unitType == "Nature")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Time":
                if (Attacker.unitType == "Time" && Defender.unitType == "Dark" || Attacker.unitType == "Time" && Defender.unitType == "ICE")
                {
                    Attacker.defens = Attacker.defens - (Attacker.defens / 4);
                }
                else if (Attacker.unitType == "Time" && Defender.unitType == "Light" || Attacker.unitType == "Time" && Defender.unitType == "Air")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "ICE":
                if (Attacker.unitType == "ICE" && Defender.unitType == "Water" || Attacker.unitType == "ICE" && Defender.unitType == "Air")
                {
                    Attacker.defens = Attacker.defens - (Attacker.defens / 4);
                }
                else if (Attacker.unitType == "ICE" && Defender.unitType == "Light" || Attacker.unitType == "ICE" && Defender.unitType == "Time")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;

        }
    }
}
