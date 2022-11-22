using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
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
        // ExampleCoroutine();
        Vector3 enemySpawnPosition = firePoint.position;
        
        InToEnemyCM.Create(enemySpawnPosition);
    }


    // IEnumerator ExampleCoroutine() {
    //     //Print the time of when the function is first called.
    //     Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     yield return new WaitForSeconds(Random.Range(2, 4));

    //     //After we have waited 5 seconds print the time again.
    //     Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    // }
}
