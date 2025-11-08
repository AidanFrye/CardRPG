using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static int playerMaxHealth = 10;
    public static int playerMana;
    public static int playerHealth;

    private void Awake()
    {
        playerHealth = playerMaxHealth;
        playerMana = 5;
    }

    public static void ChangePlayerHealth(int healthChange) 
    {
        playerHealth += healthChange;
        PlayerHealthBarController.UpdateHealthUI();
    }

    public static void ChangePlayerMana(int manaChange) 
    {
        playerMana += manaChange;
    }
}
