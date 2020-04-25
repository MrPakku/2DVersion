using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackandEvadecalculation : MonoBehaviour
{
    public Units playerUnit;
    public Units enemyunit;
    public BattleSystem Battle;

    public bool Hit;
    public bool frozen;


    public void normalEvadeCheck(Units Attcker, Units Defender)
    {
        float Rdm;
        float DefTrueEvade;
        float AttackChance;
        float HitChance;

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
        }
        
    }

    public void elemetEvadeCheck(Units Attacker, Units Defender)

    {
        TypeCompare(Attacker, Defender);
        normalEvadeCheck(Attacker, Defender);
    }

    public void TypeCompare(Units Attacker, Units Defender)
    {

    }

    public bool ElementAttack(Units Attacker, Units Enemy)
    {

        Enemy.currentHP -= (Attacker.spezialdamage - Enemy.spezialdefens);

        if (Enemy.currentHP <= 0)
            return true;
        else
            return false;

    }
    public bool NormalAttack(Units Attacker, Units Enemy)
    {
        Enemy.currentHP -= (Attacker.damage - Enemy.defens);

        if (Enemy.currentHP <= 0)
            return true;
        else
            return false;
    }


    public void Heal(Units unit, float amount)
    {
        unit.Attack4 = "Frosty Sleep";
        amount = (unit.damage + unit.spezialdamage) / 2;
        unit.currentHP += amount;

        if (unit.currentHP > unit.maxHP)
            unit.currentHP = unit.maxHP;
    }
}
