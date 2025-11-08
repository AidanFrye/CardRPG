using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QueueControl : MonoBehaviour
{
    public static List<Card> queue = new List<Card>();

    private void Update()
    {
        if(TurnManager.currentState != TurnManager.TurnState.Player)
        { 
            return; 
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(PlayHand());
        }
    }

    IEnumerator PlayHand() 
    {
        for (int i = 0; i < queue.Count; i++)
        {
            queue[i].SetPlayed(true);
            queue[i].PlayCard();
            HandControl.discard.Add(queue[i]);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Player mana: " + PlayerControl.playerMana);
        Debug.Log("Player health: " + PlayerControl.playerHealth);
        Debug.Log("Enemy health: " + GameManager.enemies[GameManager.target].GetHealth());
        queue.Clear();
        HandControl.RefillHand();
        TurnManager.SetTurnState(TurnManager.TurnState.Enemy);
    }
}
