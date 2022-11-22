using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bulletPrefabEnemy;

    // Update is called once per frame
   public void Update()
    {
        // if ( Input.GetButtonDown("Fire2")) {
        //     Shoot();
        // }
    }

    public void Shoot() {
        // Instantiate(bulletPrefabEnemy, firePoint.position, firePoint.rotation);
        Vector3 enemySpawnPosition = firePoint.position;
        // ExampleCoroutine();
        InToPlayerCM.CreateInToPlayer(enemySpawnPosition);
    }


    //     IEnumerator ExampleCoroutine() {
    //     //Print the time of when the function is first called.
    //     Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     yield return new WaitForSeconds(Random.Range(0, 4));

    //     //After we have waited 5 seconds print the time again.
    //     Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    // }
}
