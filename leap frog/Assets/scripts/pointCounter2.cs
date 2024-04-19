using System.Collections;
using UnityEngine;
using TMPro; // Use TextMeshPro

public class pointCounter2 : MonoBehaviour
{
    private int points2 = 0;
    private bool isCooldown = false;
    private float cooldownTime = 1.0f;
    public TextMeshProUGUI score2Text; // Use TextMeshProUGUI instead of Text
    public Collider jumpOverTrigger;
    public Transform player2Transform;
    public Transform player1Transform; // Reference to the Player1's Transform
    public TextMeshProUGUI gameOverScreen;

    void Start()
    {
        jumpOverTrigger.enabled = false;
        UpdatePointsText();
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpOverTrigger.enabled = true;
        }
        else
        {
            jumpOverTrigger.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player1"))
        {
            // Check if Player2 is higher than Player1
            if (transform.position.y > player1Transform.position.y && !isCooldown)
            {
                Debug.Log("Player2 is higher than Player1");

                points2++;
                UpdatePointsText();
                StartCoroutine(Cooldown());
                //check if game is over
                CheckGameOver();
            }
            else
            {
                Debug.Log("Player2 is not higher than Player1");
            }
        }
        else
        {
            Debug.Log("Other player does not have Player1 tag");
        }

    }

    void CheckGameOver()
    {
        if (points2 >= 6)
        {
            //end the game
            gameOverScreen.enabled = true;
            gameOverScreen.text = "game over, player 2 wins!";
            // Stop the game
            Time.timeScale = 0;
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }

    void UpdatePointsText()
    {
        score2Text.text = "Player 2 Points: " + points2.ToString();
    }
}
