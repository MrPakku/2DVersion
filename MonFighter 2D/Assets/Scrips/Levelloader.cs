﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Loadlevel(1));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void BattleHud()
    {
        StartCoroutine(Loadlevel(1));
    }
    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
