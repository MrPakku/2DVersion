using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public int [] LevelNr = new int [1];
    public int lastLevlNR;

    public void BattleHUD()
    {
        saveLvlNr();
        StartCoroutine(Loadlevel(1));
    }

    public void lastLevel()
    {
        StartCoroutine(Loadlevel(LevelNr[lastLevlNR]));
    }
    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void saveLvlNr()
    {
        lastLevlNR = SceneManager.GetActiveScene().buildIndex;
    }

}
