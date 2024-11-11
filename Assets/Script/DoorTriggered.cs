using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggered : MonoBehaviour
{
    Animator animator; // Componente Animator de la puerta
    bool isOpen; // Puerta abierta/cerrada

    // Lista con todos los interruptores
    [SerializeField] SwitchBehaviour[] trigger;

    int activatedTriggers; // Cuenta de interruptores activos

    // Start is called before the first frame update
    void Start()
    {
        // Inicializo valores
        animator = this.gameObject.GetComponent<Animator>();
        isOpen = false;
        activatedTriggers = 0;

        int counter;

        // Registro mi función en todos los triggers
        for (counter = 0; counter < trigger.Length; counter = counter + 1)
        {
            trigger[counter].RegisterFunctionToCall(OnTriggerActivation);
        }
    }

    private void OnTriggerActivation(bool active, SwitchBehaviour sender)
    {
        // Cuento cuántos están activos
        if (active)
        {
            // Es el trigger correcto de la secuencia
            if (sender == trigger[activatedTriggers])
            {
                activatedTriggers = activatedTriggers + 1;
            }
            else
            {
                // No es el trigger correcto

                // Restablezco los triggers activos
                activatedTriggers = 0;

                // Aviso a todos los triggers del error
                int counter;
                for (counter = 0; counter < trigger.Length; counter = counter + 1)
                {
                    trigger[counter].Error();
                }
            }
        }
        else
        {
            activatedTriggers = activatedTriggers - 1;
            if (activatedTriggers < 0)
            {
                activatedTriggers = 0;
            }
        }

        // Si la puerta está cerrada y todos los triggers se han activado
        if (activatedTriggers == trigger.Length && !isOpen)
        {
            Open();
        }
        else
        {
            // Si la puerta está abierta y no todos los triggers se han activado
            if (isOpen && activatedTriggers < trigger.Length)
            {
                Close();
            }
        }
    }

    void Open()
    {
        // Animación de abrir
        animator.SetBool("Open", true);
        isOpen = true;
    }

    void Close()
    {
        // Animación de cerrar
        animator.SetBool("Open", false);
        isOpen = false;
    }
}