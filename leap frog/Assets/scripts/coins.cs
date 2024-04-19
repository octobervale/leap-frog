using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    public static int coinCount1 = 0; // Variable to count coins
    public static int coinCount2 = 0; // Variable to count coins
    private GameObject player1; // Reference to the player1
    private GameObject player2; // Reference to the player2
    private coinManager coinManager; // Reference to the CoinManager

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the coin at a random position
        transform.position = new Vector3(Random.Range(-5f, 5f), 1f, Random.Range(-5f, 5f));
        coinManager = GameObject.FindObjectOfType<coinManager>();
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
    }


    // Update is called once per frame
    void Update()
    {
        // Check if the coin is close to the player
        if (Vector3.Distance(transform.position, player1.transform.position) < 1.0f)
        {
            // Increase the coin count and destroy the coin
            coinCount1++;
            Destroy(gameObject);
            coinManager.SpawnCoin();
        }
        // Check if the coin is close to the player
        if (Vector3.Distance(transform.position, player2.transform.position) < 1.0f)
        {
            // Increase the coin count and destroy the coin
            coinCount2++;
            Destroy(gameObject);
            coinManager.SpawnCoin();
        }
    }
}