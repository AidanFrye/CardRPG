using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private int currentCard;
    private bool cardSelected;
    public Vector3 cardPosition;
    public bool inQueue;
    public GameObject queue;
    private Card card;
    private int positionInQueue;
    private static int updateIndex;
    private void Awake()
    {
        Card card = new Card();
        this.card = card;
        card.setType(Random.Range(1, 4));
        HandController.hand.Add(card);
        cardPosition = gameObject.transform.position;
        currentCard = HandController.cardsInHand - 1;
        queue = GameObject.FindGameObjectWithTag("Play Zone");
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        switch (HandController.hand[currentCard].getType())
        {
            case 1:
                renderer.color = Color.red;
                card.setEffect("damage");
                break;
            case 2:
                renderer.color = Color.blue;
                card.setEffect("mana");
                break;
            case 3:
                renderer.color = Color.green;
                card.setEffect("heal");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cardSelected)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mouseScreenPosition).x, Camera.main.ScreenToWorldPoint(mouseScreenPosition).y, 0);
        }
        if (inQueue && !cardSelected)
        {
            gameObject.transform.position = new Vector3(queue.transform.position.x * ((float)QueueController.queue.IndexOf(card) / 2f), queue.transform.position.y, 0);

        }
    }

    private void OnMouseDown()
    {
        cardSelected = true;
        gameObject.transform.localScale -= new Vector3(0.15f, 0.15f);
    }

    private void OnMouseUp()
    {
        cardSelected = false;
        gameObject.transform.localScale += new Vector3(0.15f, 0.15f);
        if (!inQueue)
        {
            gameObject.transform.position = cardPosition;
            if (QueueController.queue.Contains(card))
            {
                QueueController.removeCard(card);
            }
        }
        else
        {
            QueueController.addCard(card);
            positionInQueue = QueueController.cardsInQueue - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (QueueController.cardsInQueue < 5)
        {
            inQueue = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inQueue = false;
    }

    public void DeleteCard()
    {
        Destroy(gameObject);
    }
}

public class Card 
{
    private int type; //1 for damage, 2 for draw, 3 for health
    private int positionInQueue;
    private string effect;
    public void setType(int type) 
    {
        this.type = type;
    }
    public int getType() 
    {
        return type;
    }

    public void setPosition(int positionInQueue) 
    {
        this.positionInQueue = positionInQueue;
    }
    public int getPosition() 
    {
        return positionInQueue;
    }
    public void setEffect(string effect) 
    {
        this.effect = effect;
    }

    public string getEffect() 
    {
        return effect;
    }
}
