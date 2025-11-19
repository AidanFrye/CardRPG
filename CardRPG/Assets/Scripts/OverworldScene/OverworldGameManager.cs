using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldGameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject gameplayCanvas;
    void Awake()
    {
        Instantiate(playerPrefab, gameplayCanvas.transform);
    }
}
