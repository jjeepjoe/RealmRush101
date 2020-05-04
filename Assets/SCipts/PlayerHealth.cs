using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    //
    private void Start()
    {
        healthText.text = playerHealth.ToString();  
    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BadGuy")
        {
            if(playerHealth <= 0)
            {
                EndOfGame();
            }
            else
            {
                playerHealth -= healthDecrease;
                healthText.text = playerHealth.ToString();
            }
        }
    }
    //
    private void EndOfGame()
    {
        Debug.Log("LOSE LOSE");
    }
}
