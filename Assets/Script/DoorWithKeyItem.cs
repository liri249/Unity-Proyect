using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DoorComportamiento))]
public class DoorWithKeyItem : MonoBehaviour
{
    DoorComportamiento door;

    [SerializeField] string[] keysName;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<DoorComportamiento>();
    }

    void OnTriggerEnter(Collider other)
    {
        InventoryBehaviour inv =
            other.gameObject.GetComponent<InventoryBehaviour>();

        if (inv != null && inv.HasItems(keysName)) // HasAllItems(inv))
        {
            door.Open();
        }
    }

    bool HasAllItems(InventoryBehaviour inv)
    {
        for (int i = 0; i < keysName.Length; i = i + 1)
        {
            if (!inv.HasItem(keysName[i]))
            {
                return false;
            }
        }

        return true;
    }

}
