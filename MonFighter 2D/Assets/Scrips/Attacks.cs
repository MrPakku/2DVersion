using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public AttackandEvadecalculation AE;
    public bool Blizzard(Units Attacker,Units Defender)
    {
        return AE.ElementAttack(Attacker, Defender);

    }
    public bool SwordSlash(Units Attacker, Units Defender)
    {

        return AE.NormalAttack(Attacker, Defender);
    }

    public void ICEBarrier(Units unit)
    {

        unit.defens = unit.evade + unit.damage;
        unit.evade = 0;

    }
    public void FrostySleep(Units unit, float amount)
    {
        AE.Heal(unit, amount);
    }
}
