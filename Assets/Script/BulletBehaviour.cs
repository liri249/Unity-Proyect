using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{ 
    [SerializeField] int damage;
    [SerializeField] float speed;
    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.LooseLife(damage);
        }
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Vector3 position = transform.localPosition;
        position = new Vector3(position.x, position.y, position.z + speed * Time.deltaTime);
        transform.localPosition = position;
    }

    public void ChangeParent(Transform newParent)
    {
        transform.SetParent(newParent);
    }
}

