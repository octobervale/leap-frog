using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for managing scenes

public class goal : MonoBehaviour
{

    public Text gameOverText; // Reference to the UI text component that will display the game over message
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This method is called when another object enters a trigger collider attached to this object
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.gameObject.CompareTag("Player1"))
        {
            gameOverText.text = "Player 1 Wins!"; // Set the game over message
         
           // Time.timeScale = 0; // Stop the game
        }
         if (other.gameObject.CompareTag("Player2"))
        {
            gameOverText.text = "Player 2 Wins!"; // Set the game over message
      
            //Time.timeScale = 0; // Stop the game
        }
    }

}