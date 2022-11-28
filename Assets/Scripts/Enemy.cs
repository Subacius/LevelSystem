using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// using SaveLoadSystemNaujas;

// [RequireComponent(typeof(SaveableEntity))]
// public class Enemy : MonoBehaviour, ISaveable
public class Enemy : MonoBehaviour
{
    private EnemyTypeSO enemyType;
    private HealthSystem healthSystem;

    // public string nameOfEnemy;

    private LevelSystem levelSystem;

    private WeaponEnemy weaponEnemy;


    [SerializeField] private GameObject particalEffectsEnemy1;


    private void Start() {
        enemyType = GetComponent<EnemyTypeHolder>().enemyType;
        healthSystem = GetComponent<HealthSystem>();
        weaponEnemy = GetComponent<WeaponEnemy>();


        // healthSystem.SetHealthAmountMax(enemyType.healthAmountMax, true);

        healthSystem.OnDead += HealthSystem_OnDied;
        // healthSystem.OnRemoveFromList += HealthSystem_OnRemoveFromList;

    }
    //HealthSystem are attached on same prefab

    public void SetLevelSystem (LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        Instantiate(particalEffectsEnemy1, gameObject.transform.position, Quaternion.identity);


        // Destroy(particalEffectsEnemy1.gameObject, 1f);
        // healthbar padidina  10 proc
        SetHealthBarSize(1f + levelSystem.GetLevelNumber() * 0.05f);
        // SetHealthAmountMax(healthSystem.GetHealthAmount() + 11);
        // Debug.Log(healthSystem.GetComponent<HealthSystem>().healthAmount);
        // int healthAmountMax = healthSystem.GetHealthAmount() + 4;
        healthSystem.SetHealthAmountMax(healthSystem.healthAmountMax + 4);
        Debug.Log("HitMax" + enemyType.hitMax);
        enemyType.SethitMax(enemyType.hitMax + 2);
        Debug.Log("HitMax" + enemyType.hitMax);
        Debug.Log("HealthAmount: " + healthSystem.GetComponent<HealthSystem>().GetHealthAmount());
        Debug.Log("HealthAmountMax: " + healthSystem.GetComponent<HealthSystem>().GetHealthAmountMax());
        transform.Find("pfHealthBar").GetComponent<HealthBar>().UpdateBar();

    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.U)){
            healthSystem.Damage(1);
        }

        if (Input.GetKeyDown(KeyCode.X)){
            weaponEnemy.Shoot();
        }
    }
    private void HealthSystem_OnDied(object sender, System.EventArgs e) {
        Destroy(gameObject);
        
        Instantiate(particalEffectsEnemy1, gameObject.transform.position, Quaternion.identity);
        particalEffectsEnemy1 = GameObject.Find("Explosion VFXEnemy1(Clone)");
        Destroy(particalEffectsEnemy1.gameObject, 1f);
    }

    private void SetHealthBarSize(float healthBarSize) {
        transform.Find("pfHealthBar").localScale = new Vector3(1f * healthBarSize, 1 , 1);
    }

    // private void SetHealthAmountMax(int healthAmountMax) {
    //     // healthSystem = GetComponent<HealthSystem>().SetHealthAmountMax(1, true)
    //     healthAmountMax = GetComponent<HealthSystem>().healthAmount + 1;
    // }



}
