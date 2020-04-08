using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRate : MonoBehaviour
{
    public AttackandEvadecalculation Hit;

    public bool frozen;
    public void frezzingRate(Unit Attacker)
    {
        if(Attacker.unitType == "ICE" && Hit.Hit == true)
        {
            //freez Ennemy return bool frozen true!
        }
    }
}