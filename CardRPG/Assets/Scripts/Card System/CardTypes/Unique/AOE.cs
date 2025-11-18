using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : Card
{
    public AOE()
    {
        SetSprite(Resources.Load<Sprite>("Sprites/Cards/AOEDamageCardSprite"));
    }

    protected override void CardEffect()
    {
        var cardString = "aoe damage";
        Effect();
        TextReplayUIControl.actions.Add("Player used an " + cardString + " card");
        TextReplayUIControl.UpdateReplayUI();
    }

    private void Effect() 
    {
        for (int i = 0; i < GameManager.enemies.Count; i++) 
        {
            GameManager.enemies[i].ChangeHealth(-2);
        }
    }
}
