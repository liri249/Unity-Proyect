using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SocialPlatforms.Impl;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 initPosition;
    [SerializeField] int life;
    [SerializeField] int maxLife;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] PauseMenu pauseMenu;



    private void Start () 
    {
        initPosition = transform.localPosition;
        lifeText.text = "Tienes " + life + " vidas";
        life = maxLife;

        pauseMenu.RegisterOnPause(PauseBall);

    }

    public int LooseLife (int lifeToLoose)
    {

        if (life - lifeToLoose > 0) 
        {
            life = life - lifeToLoose;
            lifeText.text = "Tienes " + life + " vidas";
            return life;
        }
        else
        {
            lifeText.text = "Game Over";
            return 0;
            
        }
       

    }

    public void ResetPosition()
    {
        transform.localPosition = initPosition;
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; //new Vector3(0,0,0)
        rb.angularVelocity = Vector3.zero;
    }

    private void PauseBall(bool pause)
    {
        Rigidbody rb;
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
