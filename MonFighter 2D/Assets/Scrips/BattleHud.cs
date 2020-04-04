using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text lvlText;
    public Slider hpSlider;

    public Text Attack1;
    public Text Attack2;
    public Text Attack3;
    public Text Attack4;
    public void SetHudPlayer(Unit unit)
    {
        nameText.text = unit.unitName;
        lvlText.text = "LvL " + unit.unitLvL;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;

        Attack4.text = unit.Attack4;
        Attack1.text = unit.Attack1;
        Attack2.text = unit.Attack2;
        Attack3.text = unit.Attack3;
    }

    public void SetHudEnemy(Unit unit)
    {
        nameText.text = unit.unitName;
        lvlText.text = "LvL " + unit.unitLvL;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void setHP(int HP)
    {
        hpSlider.value = HP;
    }
}
