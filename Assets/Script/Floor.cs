using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] float maxRotation;
    [SerializeField] float maxRotationy;
    [SerializeField] float speed;

    [SerializeField] PauseMenu pauseMenu;

    bool gamePaused;

    private void Start()
    {
        pauseMenu.RegisterOnPause(OnPause);

        gamePaused = false;
    }

    void Update() //Función
    {
        //LA Z
        if (!gamePaused)
        {
            bool aKeyPressed = Input.GetKey(KeyCode.A);

            if (aKeyPressed)
            {
                if ((transform.eulerAngles.z >= -1 && transform.eulerAngles.z <= maxRotation)
                    ||
                (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= 270))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z + speed);

                    transform.eulerAngles = newRotation;
                }

            }


            bool dKeyPressed = Input.GetKey(KeyCode.D);

            if (dKeyPressed)
            {
                if ((transform.eulerAngles.z >= -1 && transform.eulerAngles.z <= 90)
                    ||
                (transform.eulerAngles.z <= 360 && transform.eulerAngles.z >= (360 - maxRotation)))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z - speed);

                    transform.eulerAngles = newRotation;
                }
            }

            //LA X


            bool wKeyPressed = Input.GetKey(KeyCode.W);

            if (wKeyPressed)
            {
                if ((transform.eulerAngles.x >= -1 && transform.eulerAngles.x <= maxRotation)
                    ||
                (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= 270))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x + speed,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }

            }


            bool sKeyPressed = Input.GetKey(KeyCode.S);

            if (sKeyPressed)
            {
                if ((transform.eulerAngles.x >= -1 && transform.eulerAngles.x <= 90)
                    ||
                (transform.eulerAngles.x <= 360 && transform.eulerAngles.x >= (360 - maxRotation)))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x - speed,
                        transform.eulerAngles.y,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }

            //LA Y

            bool lKeyPressed = Input.GetKey(KeyCode.L);

            if (lKeyPressed)
            {
                if ((transform.eulerAngles.y >= -1 && transform.eulerAngles.y <= maxRotationy)
                    ||
                (transform.eulerAngles.y <= 360 && transform.eulerAngles.y >= 270))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y + speed,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }

            }


            bool kKeyPressed = Input.GetKey(KeyCode.K);

            if (kKeyPressed)
            {
                if ((transform.eulerAngles.y >= -1 && transform.eulerAngles.y <= 90)
                    ||
                (transform.eulerAngles.y <= 360 && transform.eulerAngles.y >= (360 - maxRotationy)))
                {
                    Vector3 newRotation = new Vector3(
                        transform.eulerAngles.x,
                        transform.eulerAngles.y - speed,
                        transform.eulerAngles.z);

                    transform.eulerAngles = newRotation;
                }
            }
        }
    }
    private void OnPause(bool pause)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        gamePaused = pause;
    }

    public void ResetPosition()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
