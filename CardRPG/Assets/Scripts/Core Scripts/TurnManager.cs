using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{ 
    public enum TurnState 
    {
        Player,
        Enemy,
        Wait,
        GameOver
    }
    private int currentEnemy;

    public bool enemyCoroutineStarted = false;

    public static TurnState currentState;

    private void Awake()
    {
        SetTurnState(TurnState.Player);
    }

    private void Update()
    {
        switch (currentState) 
        {
            case TurnState.Player:
                //allow for player movements
                break;
            case TurnState.Enemy:
                if (!enemyCoroutineStarted)
                {
                    StartCoroutine(EnemyTurn());
                }
                break;
            case TurnState.Wait:
                //literally do nothing
                break;
            case TurnState.GameOver:
                //end game logic
                break;
        }

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            switch (currentState)
            {
                case TurnState.Player:
                    SetTurnState(TurnState.Enemy);
                    //allow for player movements
                    break;
                case TurnState.Enemy:
                    SetTurnState(TurnState.Wait);
                    //enemy turn
                    break;
                case TurnState.Wait:
                    SetTurnState(TurnState.GameOver);
                    //literally do nothing
                    break;
                case TurnState.GameOver:
                    SetTurnState(TurnState.Player);
                    //end game logic
                    break;
            }
        }
    }

    public static void SetTurnState(TurnState newState) 
    {
        currentState = newState;
        Debug.Log(currentState.ToString());
    }

    public static void EndPlayTurn() 
    {
        currentState = TurnState.Enemy;
    }

    IEnumerator EnemyTurn() 
    {
        currentEnemy = 0;
        while (currentEnemy != GameManager.enemies.Count)
        {
            enemyCoroutineStarted = true;
            #region EnemyAttackAnimationSequence
            //set up enemyDamage and animatorVars for readability
            var enemyDamage = GameManager.enemies[currentEnemy].GetDamage();
            var animator = GameManager.enemies[currentEnemy].GetAnimator();

            //freeze the animator
            animator.speed = 0;

            //wait for half a second
            yield return new WaitForSeconds(0.5f);

            //unfreeze the animator
            animator.speed = 1;

            //set the animator to play the attack animation
            animator.Play("Attack", 0, 0f);

            //wait one frame for animator to update
            yield return null;

            //wait until finished
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            {
                yield return null;
            }
            //update health
            PlayerControl.ChangePlayerHealth(enemyDamage * -1);

            //wait for half a second after the attack
            yield return new WaitForSeconds(0.5f);

            //resume idle animation
            animator.Play("Idle", 0, 0f);
            #endregion
            currentEnemy++;
        }
        SetTurnState(TurnState.Player);
        enemyCoroutineStarted = false;
        //player turn again (or whoever it goes to next);
    }
}
