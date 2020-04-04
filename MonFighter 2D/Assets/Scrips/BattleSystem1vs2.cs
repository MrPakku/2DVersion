using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState1vs2 {START, PLAYERTURN, ENEMYTURN, ENEMYTURN2, FAINT, DEATH, WON, LOST }
public class BattleSystem1vs2 : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public Transform enemyBattleStation2;

    Unit playerUnit;
    Unit enemyUnit;
    Unit playerUnit2;
    Unit enemyUnit2;

    public Text dialogueText;
    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    public Levelloader load;
    public LevelSystem level;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(PlayerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        //GameObject playerGo2 = Instantiate(PlayerPrefab, playerBattleStation);
        //playerUnit2 = playerGo2.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        //GameObject enemyGo2 = Instantiate(enemyPrefab, enemyBattleStation);
        //enemyUnit2 = enemyGo2.GetComponent<Unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " attckes.";

        playerHUD.SetHudPlayer(playerUnit);
        enemyHUD.SetHudEnemy(enemyUnit);

        yield return new WaitForSeconds(2f);

        
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an Action";
    }
    
    IEnumerator PlayerAttack()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            Endbattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

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
        dialogueText.text = playerUnit.unitName + " heald itself.";

            yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void ONAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void ONHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

}
