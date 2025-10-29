using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueControl : MonoBehaviour
{
    public static List<Card> queue = new List<Card>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            for (int i = 0; i < queue.Count; i++) 
            {
                queue[i].SetPlayed(true);
            }
            queue.Clear();
            HandControl.RefillHand();
            PlayerControl.ChangePlayerHealth(-1);
        }
    }
}
