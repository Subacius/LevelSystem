using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer2 : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        // if ( Input.GetButtonDown("Fire1")) {
            // Shoot();
        // }
    }

    public void Shoot() {
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Vector3 enemySpawnPosition = firePoint.position;
        InToEnemyCM.Create2(enemySpawnPosition);
    }
}
