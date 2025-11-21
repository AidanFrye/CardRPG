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
            if (TurnManager.currentState == TurnManager.TurnState.Player)
            {
                TurnManager.SetTurnState(TurnManager.TurnState.Wait);
                StartCoroutine(PlayHand());
            }
        }
    }

    IEnumerator PlayHand() 
    {
        var animator = PlayerAnimation.animator;
        for (int i = 0; i < queue.Count; i++)
        {
            queue[i].PlayCard();
            HandControl.discard.Add(queue[i]);
            animator.speed = 0;
            Debug.Log("before animation number: " + i);
            yield return new WaitForSeconds(0.5f);
            Debug.Log("start animation number: " + i);
            animator.speed = 1;
            animator.Play("Attack", 0, 0f);
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            Debug.Log("end animation number: " + i);
        }
        Debug.Log("Player mana: " + PlayerControl.playerMana);
        Debug.Log("Player health: " + PlayerControl.playerHealth);
        Debug.Log("Enemy health: " + BattleGameManager.target.GetHealth());
        queue.Clear();
        HandControl.RefillHand(7);
        animator.Play("Idle");
        TurnManager.SetTurnState(TurnManager.TurnState.Enemy);
    }
}
