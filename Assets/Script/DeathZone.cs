using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{ 
    [SerializeField] int lifeToLoose;
    private void OnTriggerEnter(Collider other)
    {

        PlayerBehaviour player;
        player = other.gameObject.GetComponent<PlayerBehaviour>();
        

        if (player != null)
        {
            int life;            
            life = player.LooseLife(lifeToLoose);
            if (life > 0) 
            {
                player.ResetPosition();
            }
            
        }
        else
        {
            Destroy(other.gameObject);
        }  

    }
}

