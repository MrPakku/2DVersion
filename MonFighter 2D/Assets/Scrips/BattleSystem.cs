using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState {START, PLAYERTURN, ENEMYTURN, FAINT, FROZEN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;
    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    // Scrips
    public Levelloader load;
    public LevelSystem level;
    public ContinueField con;
    public ContinueField PlOP;
    public ContinueField ChooseAttack;
    public Player Pl;
    public AttackandEvadecalculation Attack;

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

        playerUnit.UpdateStats(); // this will be at the end of the fight later !
        enemyUnit.UpdateStats();
        dialogueText.text = "A wild " + enemyUnit.unitName + " attckes.";
        
        playerHUD.SetHudPlayer(playerUnit);
        PlOP.Show();
        enemyHUD.SetHudEnemy(enemyUnit);

        Debug.Log(playerUnit.unitLvL + "current EXP: " + playerUnit.level.Exp + ", " + playerUnit.damage+ "\n Enemy dmg: " + enemyUnit.damage);
        yield return new WaitForSeconds(1f);

        if(playerUnit.speed >= enemyUnit.speed)
        {
            yield return new WaitForSeconds(1f);
            state = BattleState.PLAYERTURN;
            dialogueText.text = "Choose an Action.";
        }
        else
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "The Enemy is faster than you and Attcks first.";
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        
    }

    IEnumerator SetupBattleChangeMon()
    {

        GameObject playerGo = Instantiate(PlayerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(EnemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        playerUnit.UpdateStats(); // this will be at the end of the fight later !
        enemyUnit.UpdateStats();
        dialogueText.text = "A wild " + enemyUnit.unitName + " attckes.";

        playerHUD.SetHudPlayer(playerUnit);
        PlOP.Show();
        enemyHUD.SetHudEnemy(enemyUnit);


        yield return new WaitForSeconds(1f);

        if (playerUnit.speed >= enemyUnit.speed)
        {
            yield return new WaitForSeconds(1f);
            state = BattleState.PLAYERTURN;
            dialogueText.text = "Choose an Action.";
        }
        else
        {
            yield return new WaitForSeconds(1f);
            dialogueText.text = "The Enemy is faster than you and Attcks first.";
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    
    IEnumerator PlayerAttack(int option)
    {
        bool fainted = false;

        switch (option)
        {
            case 1:
                Attack.normalEvadeCheck(playerUnit, enemyUnit);
                if (Attack.Hit)
                    fainted = enemyUnit.TakeDamage(playerUnit.damage);
                break;
            case 2:
                Attack.elemetEvadeCheck(playerUnit, enemyUnit);
                if (Attack.Hit)
                    fainted = enemyUnit.TakeDamage(playerUnit.damage);
                Debug.Log(playerUnit.damage);
                break;
            case 3:
                enemyUnit.currentHP = 0;
                fainted = true;
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
            PlOP.Hide();
            con.Show();
            dialogueText.text = "The Enemy fainted do you\nwant to kill him?";
            yield return new WaitForSeconds(0.5f);
            state = BattleState.FAINT;

        }
        else
        {
            if(state == BattleState.FROZEN)
            {
                dialogueText.text = enemyUnit.unitName + " is frozen and cant move.";
                yield return new WaitForSeconds(1);
                dialogueText.text = "Choose an Action.";
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            
        }
    }
    public void PlayerChosing(string X)
    {
        switch (X)
        {
            case "Attack":
                ChooseAttack.Show();
                break;
            case "Item":
                break;
            case "Run":
                break;
            case "Change":
                break;
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
                Attack.normalEvadeCheck(enemyUnit, playerUnit);
                if (Attack.Hit)
                    dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack1;
                    isDead = playerUnit.TakeDamage(enemyUnit.damage);
                break;
            case 2:
                Attack.elemetEvadeCheck(enemyUnit, playerUnit);
                if (Attack.Hit)
                    dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack1;
                    isDead = playerUnit.TakeDamage(enemyUnit.damage);
                break;
            case 3:
                Attack.normalEvadeCheck(enemyUnit, playerUnit);
                if (Attack.Hit)
                    dialogueText.text = enemyUnit.unitName + " attacks using " + enemyUnit.Attack1;
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
            dialogueText.text = "Choose an Action.";
        }
    }
    void Endbattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Enemy Defeated.";
            playerUnit.level.addExp(enemyUnit.level.Exp / 20);
            playerUnit.UpdateStats();
            Debug.Log(playerUnit.unitLvL);
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
        StartCoroutine(PlayerAttack(1));
        ChooseAttack.Hide();
        PlOP.Show();
    }

    public void ONAttackButton2()
    {
        StartCoroutine(PlayerAttack(2));
        ChooseAttack.Hide();
        PlOP.Show();
    }
    public void ONAttackButton3()
    {
        StartCoroutine(PlayerAttack(3));
        ChooseAttack.Hide();
        PlOP.Show();
    }
    public void ONHealButton()
    {
        StartCoroutine(PlayerHeal());
        ChooseAttack.Hide();
        PlOP.Show();
    }
    public void Att()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        Debug.Log("HIT");
        PlOP.Hide();
        PlayerChosing("Attack");
    }
}
