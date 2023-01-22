using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class WeaponEnemy : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bulletPrefabEnemy;

    public event EventHandler OnExperienceChangedNaujasEnemy;


    // private LevelSystem levelSystem;

    // private LevelWindowEnemy levelWindowEnemy;


    // [SerializeField] private Text levelText;

    // [SerializeField] private Image expierenceBarImage;

    // Update is called once per frame
   public void Update()
    {
        if ( Input.GetButtonDown("Fire2")) {
            Shoot();
        }
    }

    public void Shoot() {
        // Instantiate(bulletPrefabEnemy, firePoint.position, firePoint.rotation);
        Vector3 enemySpawnPosition = firePoint.position;
        // ExampleCoroutine();
        InToPlayerCM.CreateInToPlayer(enemySpawnPosition);

        OnExperienceChangedNaujasEnemy?.Invoke(this, EventArgs.Empty);
        // levelWindowsEnemy.GetComponent<LevelWindowEnemy>().AddExpToButton();

            // levelSystem.AddExperience(25);
            // Debug.Log("ooooooooooooooooooooooooooo");

    }


}
