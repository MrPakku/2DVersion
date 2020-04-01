using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text lvlText;
    public Slider hpSlider;

    public void SetHud(Unit unit)
    {
        nameText.text = unit.unitName;
        lvlText.text = "Lvl " + unit.unitLvL;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void setHP(int HP)
    {
        hpSlider.value = HP;
    }
}
