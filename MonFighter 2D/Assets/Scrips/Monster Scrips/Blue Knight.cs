using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKnight : MonoBehaviour
{
    public LevelSystem level;

    public string unitName = "Blue Kinght";
    public string unitType = "ICE";
    public int unitLvL;

    //Stats for lvl 1
    public float damage = 7;
    public float defens = 6;
    public float speed = 5;
    public float evade = 4;
    public float elementdamage = 10;
    public float elemetdefens = 8;

    public float maxHP = 30;
    public float currentHP = 30;

    public string AttackName1;

    public void Start()
    {
        level = new LevelSystem(unitLvL, OnLvLUp);

        unitLvL = level.currentLvl;
    }

    public void UpdateStats()
    {

        for (int cuLvL = 1; cuLvL != unitLvL; cuLvL++)
        {
            damage += Random.Range(2, 4);
            defens += Random.Range(2, 4);
            speed += Random.Range(2, 4);
            evade += Random.Range(2, 4);
            elementdamage += Random.Range(3, 5);
            elemetdefens += Random.Range(2, 4);

            maxHP += Random.Range(10, 15);

            currentHP = maxHP;

        }

    }


    public void OnLvLUp()
    {
        damage += Random.Range(2, 4);
        defens += Random.Range(2, 4);
        speed += Random.Range(2, 4);
        evade += Random.Range(2, 4);
        elementdamage += Random.Range(2, 4);
        elemetdefens += Random.Range(2, 4);

        maxHP += Random.Range(10, 15);

        currentHP = maxHP;
    }
    public bool TakeDamage(float dmg, Unit unit)
    {
        currentHP -= (dmg - unit.defens);

        if (currentHP <= 0)
            return true;
        else
            return false;

    }

    public void Attack1(Unit unit) 
    {
        AttackName1 = "Blizzard";



    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
