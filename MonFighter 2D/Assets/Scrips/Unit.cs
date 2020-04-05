using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public LevelSystem level;

    public string unitName;
    public string unitType;
    public int unitLvL;

    public float damage;
    public float defens;
    public float speed;
    public float evade;
    public float crit;

    public float maxHP;
    public float currentHP;

    public string Attack1;
    public string Attack2;
    public string Attack3;
    public string Attack4;

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

        maxHP += Random.Range(10, 15);

        currentHP = maxHP;
    }
    public bool TakeDamage(float dmg)
    {
        currentHP -= (dmg - defens);

        if (currentHP <= 0)
            return true;
        else
            return false;

    }

    public void Heal(float amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
