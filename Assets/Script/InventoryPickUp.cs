using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPickUp : MonoBehaviour
{
    [SerializeField] string itemName;
    Item it;

    private void Start()
    {
        it = new Item();
        it.SetName(itemName);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventario inv =
            other.gameObject.GetComponent<Inventario>();
        if (inv != null)
        {
            Debug.Log(inv.PrintAllItems());
            Debug.Log(inv.AddItem(it));
            Debug.Log(inv.PrintAllItems());

            Debug.Log(inv.HasItem(it));
            Debug.Log("Objeto: " + inv.HasItem("objeto"));
            Destroy(this.gameObject);
        }
    }
}
