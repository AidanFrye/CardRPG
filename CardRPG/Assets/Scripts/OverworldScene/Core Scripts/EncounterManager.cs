using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterManager : MonoBehaviour
{
    public static EncounterManager Instance { get; private set; }
    public Enemy.EnemyType encounterType;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerEncounter(Enemy.EnemyType enemyType) 
    {
        encounterType = enemyType;
        SceneManager.LoadScene("Battle");
    }
}