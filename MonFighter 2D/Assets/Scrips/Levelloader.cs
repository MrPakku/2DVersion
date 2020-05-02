using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelloader : MonoBehaviour
{
    public Animator transition;

    public Player player;
    public PlayerMovment move;


    public float transitionTime = 1f;
    public Vector2 position;

    public void BattleHUD()
    {
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            SavingSystem.SavePlayer(player);
            PlayerPrefs.SetInt("last LvL", SceneManager.GetActiveScene().buildIndex);
            StartCoroutine(Loadlevel(1));
        }
        else 
        {
            StartCoroutine(Loadlevel(PlayerPrefs.GetInt("last LvL")));
            SavingSystem.LoadPlayer();
        }
    }
    IEnumerator Loadlevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void savePlayer(Player player)
    {
        SavingSystem.SavePlayer(player);
    }
     
}
