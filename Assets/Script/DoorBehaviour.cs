using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorBehaviour : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();

        Open(isOpen);
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void Switch()
    {
        Open(!isOpen);
    }

    public void Open(bool hasToOpen)
    {
        if (hasToOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        animator.SetBool("Open", true);
        isOpen = true;
    }

    public void Close()
    {
        animator.SetBool("Open", false);
        isOpen = false;
    }
}
