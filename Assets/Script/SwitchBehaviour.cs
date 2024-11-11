
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] Color activeColor;
    [SerializeField] Color deactiveColor;
    [SerializeField] Color errorColor;

    [SerializeField] float errorTime;

    [SerializeField] bool deactivable;

    MeshRenderer rend;

    int state; // 0 desactivado; 1 activado; -1 error

    public delegate void TriggerDelegate(bool b, SwitchBehaviour sender);
    event TriggerDelegate OnChangeState;

    public void Activate(bool activate)
    {
        if (activate)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }

    public void Activate()
    {
        if (state != 1)
        {
            state = 1;
            rend.materials[1].color = activeColor;
            if (OnChangeState != null)
            {
                OnChangeState(true, this);
            }
        }
    }

    public void Deactivate()
    {
        if (state != 0)
        {
            state = 0;
            rend.materials[1].color = deactiveColor;
            if (OnChangeState != null)
            {
                OnChangeState(false, this);
            }
        }
    }

    public void Error()
    {
        if (state != -1)
        {
            state = -1;
            rend.materials[1].color = errorColor;
            StartCoroutine(DeactivateDelay());
        }
    }

    IEnumerator DeactivateDelay()
    {
        yield return new WaitForSeconds(errorTime);
        Deactivate();
    }

    void Start()
    {
        state = 0;
        rend = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void RegisterFunctionToCall(TriggerDelegate f)
    {
        OnChangeState += f;
    }

    public void UnregisterFunctionToCall(TriggerDelegate f)
    {
        OnChangeState -= f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (state == 0)
            {
                Activate();
            }
            else
            {
                if (state == 1 && deactivable)
                {
                    Deactivate();
                }
            }
        }
    }
}
