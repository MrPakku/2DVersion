using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public LevelSystem level;

    public string unitName;
    public int unitLvL;

    public int damage;
    public int defens;
    public int speed;
    public int evade;

    public int maxHP;
    public int currentHP;

    public string Attack1;
    public string Attack2;
    public string Attack3;
    public string Attack4;

    public void Start()
    {
        level = new LevelSystem(unitLvL, OnLvLUp);

        unitLvL = level.currentLvl;
        UpdateStats();
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
        Debug.Log("damage " + damage + "\ndef" + defens + "\nspeed" + speed + "\nevade" + evade + "\nMaxHP " + maxHP);
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


    public bool TakeDamage(int dmg)
    {
        currentHP -= (dmg - defens);

        if (currentHP <= 0)
            return true;
        else
            return false;

    }

    public void Heal (int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
