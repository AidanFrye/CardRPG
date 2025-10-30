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
                StartCoroutine(EnemyTurn());
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
            Debug.Log(currentState.ToString());
        }
    }

    public static void SetTurnState(TurnState newState) 
    {
        currentState = newState;
    }

    public static void EndPlayTurn() 
    {
        currentState = TurnState.Enemy;
    }

    IEnumerator EnemyTurn() 
    {
        yield return new WaitForSeconds(1f);
        //Enemy attack logic
        yield return new WaitForSeconds(1f);
        //wait until end of attack animation
        SetTurnState(TurnState.Player);
        //player turn again (or whoever it goes to next);
    }
}
