using System.Collections;
using UnityEngine;
using TMPro; // Use TextMeshPro

public class pointCounter1 : MonoBehaviour
{
    private int points1 = 0;
    private bool isCooldown = false;
    private float cooldownTime = 1.0f;
    public TextMeshProUGUI score1Text; // Use TextMeshProUGUI instead of Text
    public Collider jumpOverTrigger;
    public Transform player1Transform;
    public Transform player2Transform; // Reference to the Player2's Transform
    public TextMeshProUGUI gameOverScreen;


    void Start()
    {
        jumpOverTrigger.enabled = false;
        UpdatePointsText();
        gameOverScreen.enabled = false;
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
        if (other.gameObject.CompareTag("Player2"))
        {
            // Check if Player1 is higher than Player2
            if (transform.position.y > player2Transform.position.y && !isCooldown)
            {
                Debug.Log("Player1 is higher than Player2");

                points1++;
                UpdatePointsText();
                CheckGameOver();
                StartCoroutine(Cooldown());
                //check if game is over
                
            }
            else
            {
                Debug.Log("Player1 is not higher than Player2");
            }
        }
        else
        {
            Debug.Log("Other player does not have Player2 tag");
        }
    }

    void CheckGameOver()
    {
        if (points1 >= 6)
        {
            //end the game
            gameOverScreen.enabled = true;
            gameOverScreen.text = "game over, player 1 wins!";
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
        score1Text.text = "Player 1 Points: " + points1.ToString();
    }
}