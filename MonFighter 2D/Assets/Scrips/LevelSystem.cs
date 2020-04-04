using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class LevelSystem 
{

    public int Exp;
    public int currentLvl;

    public int Max_Exp;
    public int Max_LvL = 99;

    public Action onLevelUp;

    public LevelSystem(int level, Action onLevUp)
    {
        Max_Exp = GetXPforLevel(99);

        currentLvl = level;
        Exp = GetXPforLevel(level);
        onLevelUp = onLevUp;
        
    }

    public int GetXPforLevel(int level)
    {

        if (level > Max_LvL)
            return 0;

        int firstPass = 0;
        int secondPass = 0;

        for(int LevelCycle = 1; LevelCycle < level; LevelCycle++)
        {

            firstPass += (int)Math.Floor(LevelCycle + (300.0f * Math.Pow(2.0f, LevelCycle / 7.0f)));
            secondPass = firstPass / 4;

        }

        if (secondPass > Max_Exp && Max_Exp != 0)
            return Max_Exp;

        if(secondPass < 0)
            return Max_Exp;

        return secondPass;
    }

    public int GetLevelforXP(int exp)
    {
        if (exp > Max_Exp)
            return Max_LvL;

        int firstPass = 0;
        int secondPass = 0;

        for (int LevelCycle = 1; LevelCycle <= Max_LvL; LevelCycle++)
        {

            firstPass += (int)Math.Floor(LevelCycle + (300.0f * Math.Pow(2.0f, LevelCycle / 7.0f)));
            secondPass = firstPass / 4;
            if (secondPass > exp)
                return LevelCycle;

        }

        if (exp > secondPass)
            return Max_LvL; 
        return 0;

    }

    public bool addExp(int amount)
    {

        if(amount + Exp < 0 || Exp > Max_Exp)
        {
            if (Exp > Max_Exp)
                Exp = Max_Exp;
            return false;
        }

        int oldLevel = GetLevelforXP(Exp);
        Exp += amount;

        if (oldLevel < GetLevelforXP(Exp))
        {
            if(currentLvl < GetLevelforXP(Exp))
            {

                currentLvl = GetLevelforXP(Exp);
                if (onLevelUp != null)
                    onLevelUp.Invoke();
                return true;
            }
        }
        return false;
    }
}


