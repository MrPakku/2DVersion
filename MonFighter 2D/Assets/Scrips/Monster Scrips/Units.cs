using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[System.Serializable]
public class Units : MonoBehaviour
{

    public enum Types { Normal, Knight, Berzerker, Archer, Rouge, Mage }


    public LevelSystem level;

    public string unitName;
    public int unitLvL;
    public int LevelCount = 1;
    public Types unitType;

    public float damage;
    public float defens;
    public float speed;
    public float evade;
    public float spezialdamage;
    public float spezialdefens;

    public float maxHP;
    public float currentHP;

    public string Attack1;
    public string Attack2;
    public string Attack3;
    public string Attack4;

    public Action LevelUP;

    public void AddEXP(bool won, int EXPamount)
    {
        if (won)
        {
            level.addExp(EXPamount);
        }
    }
    public void UpdateStats()
    {
        LevelUP = OnLvLUp;
        level = new LevelSystem(unitLvL, LevelUP);
        OnLvLUp();

    }
    public void OnLvLUp()
    {
        while (LevelCount < level.currentLvl)
        {
            damage += Random.Range(2, 4);
            defens += Random.Range(2, 4);
            speed += Random.Range(2, 4);
            evade += Random.Range(2, 4);
            spezialdamage += Random.Range(2, 4);
            spezialdefens += Random.Range(2, 4);

            maxHP += Random.Range(10, 15);
            currentHP = maxHP;

            LevelCount++;
        }
        unitLvL = level.currentLvl;
    }

}
