using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tes : MonoBehaviour
{

    public int Exp;

    public int Max_Exp;
    public int Max_LvL = 99;

    public int XPAmountCal(int level)
    {

        if (level > Max_LvL)
            return 0;

        int firstPass = 0;
        int secondPass = 0;

        for (int LevelCycle = 1; LevelCycle < level; LevelCycle++)
        {

            firstPass += (int)Math.Floor(LevelCycle + (300.0f * Math.Pow(2.0f, LevelCycle / 7.0f)));
            secondPass = firstPass / 4;

        }

        if (secondPass > Max_Exp && Max_Exp != 0)
            return Max_Exp;

        if (secondPass < 0)
            return Max_Exp;

        return secondPass;
    }

    public void XPAmount(int LVL)
    {
        Exp = XPAmountCal(LVL);

        Exp = Exp / 3;

        
    }
}
