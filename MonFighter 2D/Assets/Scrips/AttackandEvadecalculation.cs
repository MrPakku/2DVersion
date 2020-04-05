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


    public void EvadeCheck(Unit Attcker, Unit Defender)
    {
        Debug.Log("IT Started");
        float DefTrueEvade;
        float AttackChance;
        float HitChance = 0;

        DefTrueEvade = Defender.evade - Attcker.evade;
        AttackChance = Random.Range(0, 100 - (DefTrueEvade / 10));
        HitChance = Random.Range(0, AttackChance);

        if (HitChance <= 0)
        {
            Battle.dialogueText.text = Attcker.unitName + " missed his attack";
            Hit = false;
        }
        else if(AttackChance < DefTrueEvade)
        {
            Battle.dialogueText.text = Defender.unitName + " dodged your attack.";
            Hit = false;
        }
        else
        {
            CritCheck(Attcker, Defender);
            Hit = true;
        }

    }

    public void CritCheck(Unit Attcker, Unit Defender)
    {
        float critChance;

        critChance = Random.Range(0, Attcker.crit) - Random.Range(0, 100);

        if (critChance >= 0)
        {
            Attcker.damage = Attcker.damage + (Attcker.damage / 2);

            Battle.dialogueText.text = Attcker.unitName + " landet a critical Hit";
        }

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
                else if (Attacker.unitType == "Fire" && Defender.unitType == "Dark" || Attacker.unitType == "Fire" && Defender.unitType == "Nature")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;
            case "Water":
                if (Attacker.unitType == "Water" && Defender.unitType == "Light" || Attacker.unitType == "Water" && Defender.unitType == "Nature")
                {
                    Attacker.damage = Attacker.damage - ((Attacker.damage / 100)*5);
                    Attacker.speed = Attacker.speed - ((Attacker.speed / 100) * 5);
                    Attacker.evade = Attacker.evade - ((Attacker.evade / 100) * 5);
                    Attacker.defens = Attacker.defens - ((Attacker.defens / 100) * 5);
                    Attacker.crit = Attacker.crit - ((Attacker.crit / 100) * 5);
                }
                else if (Attacker.unitType == "Water" && Defender.unitType == "Fire" || Attacker.unitType == "Water" && Defender.unitType == "ICE")
                {
                    Attacker.damage = Attacker.damage * 2;
                }
                break;

        }
    }
}
