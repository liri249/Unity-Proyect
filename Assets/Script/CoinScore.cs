using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinScore : MonoBehaviour
{
    [SerializeField] int scoreToAdd;

    private void OnTriggerEnter(Collider other)
    {       
        PlayerScore player;
        player = other.gameObject.GetComponent<PlayerScore>();

        if (player != null)
        {
            player.AddScore(scoreToAdd);
            Destroy(this.gameObject);
        }
    }
   
}
