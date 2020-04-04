using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, FAINT, DEATH, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;
    //public Text dialogueText2;
    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    public Levelloader load;
    public LevelSystem level;
    public ContinueField con;
    public Player Pl;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        
    }

    IEnumerator SetupBattle()
    {
        
        GameObject playerGo = Instantiate(PlayerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(EnemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();


        dialogueText.text = "A wild " + enemyUnit.unitName + " attckes.";

        playerHUD.SetHudPlayer(playerUnit);
        enemyHUD.SetHudEnemy(enemyUnit);

        yield return new WaitForSeconds(2f);

        if(playerUnit.speed >= enemyUnit.speed)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
        
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an Action";
    }
    
    IEnumerator PlayerAttack(int option)
    {
        bool fainted = false;

        switch (option)
        {
            case 1:
                fainted = enemyUnit.TakeDamage(playerUnit.damage + 5);
                break;
            case 2:
                fainted = enemyUnit.TakeDamage(playerUnit.damage + 10);
                break;
            case 3:
                fainted = enemyUnit.TakeDamage(playerUnit.damage);
                break;
        }
        if (enemyUnit.currentHP <= 0)
        {
            enemyUnit.currentHP = 1;
        }
      
        enemyHUD.setHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (fainted)
        {
            con.show();
            yield return new WaitForSeconds(0.5f);
            state = BattleState.FAINT;

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        int enemyOption;
        enemyOption = Random.Range(1, 4);

        bool isDead = false;

        switch (enemyOption)
        {
            case 1:
                dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack1;
                isDead = playerUnit.TakeDamage(enemyUnit.damage);
                break;
            case 2:
                dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack2;
                isDead = playerUnit.TakeDamage(enemyUnit.damage);
                break;
            case 3:
                dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack3;
                isDead = playerUnit.TakeDamage(enemyUnit.damage);
                break;
            case 4:
                enemyUnit.Heal(enemyUnit.damage / 3);

                enemyHUD.setHP(enemyUnit.currentHP);
                dialogueText.text = enemyUnit.unitName + " heald himself using " + enemyUnit.Attack4;
                break;
        }
        yield return new WaitForSeconds(1f);

        playerHUD.setHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            Endbattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    void Endbattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Enemy Defeated.";
            //load.lastLevel();
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            //load.lastLevel();
        }
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(playerUnit.damage /3);

        playerHUD.setHP(playerUnit.currentHP);
        dialogueText.text = playerUnit.unitName + " heald himself.";

        yield return new WaitForSeconds(1f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
    public void Kill(int kill)
    {
        state = BattleState.WON;
        con.Hide();

        switch (kill)
        {
            case 1:
                Pl.Killcount++;
                enemyHUD.setHP(0);
                break;
            case 2:
                enemyUnit.currentHP = 1;
                break;
        }
        Endbattle();
    }

    public void ONFaintYes()
    {
        if (state != BattleState.FAINT)
            return;
        Kill(1);
        
    }
    public void ONFaintNo()
    {
        if (state != BattleState.FAINT)
            return;
        Kill(2);

    }
    public void ONAttackButton1()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack(1));
    }

    public void ONAttackButton2()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack(2));
    }
    public void ONAttackButton3()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack(3));
    }
    public void ONHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
