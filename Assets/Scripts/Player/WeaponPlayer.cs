using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bulletPrefab;

    // public event EventHandler OnExperienceChangedNaujas;

    // private LevelWindowPlayer levelWindowPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            Shoot();
        }
    }

    public void Shoot() {
        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // ExampleCoroutine();
        Vector3 enemySpawnPosition = firePoint.position;
        
        InToEnemyCM.Create(enemySpawnPosition);
        // levelWindowPlayer = FindObjectOfType<LevelWindowPlayer>();
        // levelWindowPlayer.OnExperienceChangedNaujas += LevelWindowPlayer_OnLevelChangedNaujas;

        // OnExperienceChangedNaujas?.Invoke(this, EventArgs.Empty);

    }

    // private void LevelWindowPlayer_OnLevelChangedNaujas(object sender, EventArgs e)
    // {
    //     Debug.Log("bombastika");
    // }


    // IEnumerator ExampleCoroutine() {
    //     //Print the time of when the function is first called.
    //     Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //     //yield on a new YieldInstruction that waits for 5 seconds.
    //     yield return new WaitForSeconds(Random.Range(2, 4));

    //     //After we have waited 5 seconds print the time again.
    //     Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    // }
}
