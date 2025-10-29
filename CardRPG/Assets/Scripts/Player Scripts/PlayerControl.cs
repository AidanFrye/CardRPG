using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static int playerHealth;

    private void Awake()
    {
        playerHealth = 10;
    }

    public static void ChangePlayerHealth(int healthChange) 
    {
        playerHealth += healthChange;
        Debug.Log("Player health is now: " + playerHealth);
    }
}
