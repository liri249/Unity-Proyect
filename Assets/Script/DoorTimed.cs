using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimed : MonoBehaviour
{
    [SerializeField] float openedTime;
    [SerializeField] float closedTime;
    float timeCounter;

    DoorBehaviour door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<DoorBehaviour>();

        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter = timeCounter + Time.deltaTime;

        float targetTime;
        if (door.IsOpen())
        {
            targetTime = openedTime;
        }
        else
        {
            targetTime = closedTime;
        }

        if (timeCounter > targetTime)
        {
            door.Switch();
            timeCounter = 0;
        }
    }
}
