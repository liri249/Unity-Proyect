using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Progress;

public class Inventario : MonoBehaviour
{
    List<Item> items; // Colección de objetos en el inventario

    private void Start()
    {
        items = new List<Item>();
    }

    public Item GetItem(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            // Si me salgo del array
            return null;
        }
        else
        {
            // Si no, devuelvo lo que haya en esa posición (puede ser null)
            return items[index];
        }
    }

    public Item GetItem(string name)
    {
        foreach (Item actual in items)
        {
            // Recorrer el array
            // Verificar nombre
            if (actual.GetName() == name)
            {
                return actual;
            }
        }

        return null;
    }

    public bool AddItem(Item newItem)
    {
        // Verificar si ya tengo el objeto
        if (HasItem(newItem))
        {
            return false;
        }
        else
        {
            items.Add(newItem);
            return true;
        }
    }

    public string PrintAllItems()
    {
        string returnedString = "";
        foreach (Item item in items)
        {
            returnedString = returnedString + item.GetName() + " ";
        }

        return returnedString;
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }

    public void RemoveItem(Item item)
    {
        RemoveItem(item.GetName());
    }

    public void RemoveItem(string name)
    {
        foreach (Item itemActual in items)
        {
            // Verificar nombre
            if (itemActual.GetName() == name)
            {
                items.Remove(itemActual);
                return;
            }
        }
    }

    public void UseItem(string name)
    {
        Item it = GetItem(name);
        if (it != null)
        {
            it.Use();
        }
    }

    public void UseItem(int index)
    {
        Item it = GetItem(index);
        if (it != null)
        {
            it.Use();
        }
    }

    public bool HasItem(string name)
    {
        foreach (Item it in items)
        {
            if (it.GetName() == name)
            {
                return true;
            }
        }

        return false;
    }

    public bool HasItem(Item item)
    {
        return HasItem(item.GetName());
    }
}
