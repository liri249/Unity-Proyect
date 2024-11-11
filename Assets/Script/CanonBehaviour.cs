using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;

    [SerializeField] int gustCount;
    [SerializeField] float shootingDelay;
    [SerializeField] float gustDelay;

    private void Start()
    {
        StartCoroutine(CanonSequence());
    }

    void Shoot()
    {
        GameObject instantiatedBullet;

        instantiatedBullet = GameObject.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);

        instantiatedBullet.GetComponent<BulletBehaviour>().ChangeParent(transform);
    }

    IEnumerator CanonSequence()
    {
        while (true)
        {
            for (int counter = 0; counter < gustCount; counter = counter + 1)
            {
                Shoot();
                yield return new WaitForSeconds(shootingDelay);
            }
            yield return new WaitForSeconds(gustDelay);
        }
    }
}


