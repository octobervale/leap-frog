using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Use TextMeshPro

public class coinManager : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab
    public TextMeshProUGUI coin1; // Reference to the coin1 TextMeshProUGUI
    public TextMeshProUGUI coin2; // Reference to the coin2 TextMeshProUGUI

    void Start()
    {
        // Spawn the coin at a random position
        SpawnCoin();
    }

    // Method to spawn a new coin
    public void SpawnCoin()
    {
        // Instantiate a new coin at a random position
        Instantiate(coinPrefab, new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f)), Quaternion.identity);
    }
    void Update()
    {
        // Update the coin text
        coin1.text = "player 1 Coins: " + coins.coinCount1.ToString();
        coin2.text = "Player 2 Coins: " + coins.coinCount2.ToString();
    }
}
