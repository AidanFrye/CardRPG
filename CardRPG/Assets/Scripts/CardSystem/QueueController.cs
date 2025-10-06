using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    public static List<Card> queue = new List<Card>();
    public static int cardsInQueue;
    public HandController handController;
    // Start is called before the first frame update
    void Start()
    {
        cardsInQueue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playHand();
        }
    }

    public static void addCard(Card card) 
    {
        if (cardsInQueue < 5)
        {
            cardsInQueue++;
            queue.Add(card);
        }
    }

    public static void removeCard(Card card) 
    {
        cardsInQueue--; 
        queue.Remove(card);
    }

    public void playHand() 
    {
        for (int i = 0; i < queue.Count; i++) 
        {
            Debug.Log(queue[i].getEffect());
        }
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Card");
        foreach (GameObject gameobject in gameobjects)
        {
            Destroy(gameobject);
        }
        handController.loadNewHand();
    }
}
