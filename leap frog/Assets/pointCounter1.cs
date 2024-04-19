using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter1 : MonoBehaviour
{
        public int points1 = 0;
        private bool isCooldown = false;
        public float cooldownTimee = 1.0f;
        public Text score1Text;
    
    void OnTriggerEnter(Collider other)
    {
        movement2 player2Movement = other.gameObject.GetComponent<movement2>();
       // if (other.gameObject.CompareTag("Player1") && player2Movement != null && player2Movement.isJumpOvere && !isCooldown)
       if (other.gameObject.CompareTag("Player1") && !isCooldown)
        {
            Debug.Log("triggered");
            points1++;
           // Debug.Log("Player 1 Points: " + points1);
            score1Text.text = "Player 1 Points: " + points1;
            StartCoroutine(Cooldown());
        }
    }


    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTimee);
        isCooldown = false;
        Debug.Log("cooldown over");
    }
}
