using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointCounter2 : MonoBehaviour
{
        private int points2 = 0;
        private bool isCooldown = false;
        private float cooldownTime = 1.0f;
        public Text score2Text;
    
    void OnTriggerEnter(Collider other)
    {
        P1Movement playerMovement = other.gameObject.GetComponent<P1Movement>();
       // if (playerMovement != null && playerMovement.isJumpOver && !isCooldown)
       if (other.gameObject.CompareTag("Player2") && !isCooldown)
        {
            Debug.Log("triggered 1");
            points2++;
            //Debug.Log("Player 2 Points: " + points2);
            score2Text.text = "Player 2 Points: " + points2;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
