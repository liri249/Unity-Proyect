using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBigBehaviour : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Player") 
        {
            Vector3 scale = Other.transform.localScale;
            scale = new Vector3(scale.x * scaleFactor, scale.y * scaleFactor, scale.z * scaleFactor);
            Other.gameObject.transform.localScale = scale;

            Destroy(this.gameObject);
        }
    }
}
