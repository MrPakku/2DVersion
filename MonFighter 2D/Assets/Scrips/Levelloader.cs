using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
 
    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void BattleHud()
    {
        int LevelNR;

        LevelNR = SceneManager.GetActiveScene().buildIndex;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(Loadlevel(LevelNR -1));
        }
        else
        {
            StartCoroutine(Loadlevel(1));
        }
    }
    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
