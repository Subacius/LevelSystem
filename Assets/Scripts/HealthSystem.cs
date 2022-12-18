using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SaveLoadSystem;
// using SaveLoadSystemNaujas;

[RequireComponent(typeof(SaveableEntity))]

public class HealthSystem : MonoBehaviour, ISaveable
{
    [SerializeField] public int healthAmountMax;
    
    public int healthAmount;
    
    public event EventHandler OnDamaged;

    public event EventHandler OnDead;

    public event EventHandler OnDead2;

    public event EventHandler OnRemoveFromList;

    public event EventHandler OnRemoveFromList2Unit;

    private GameObject [] pfHealthbarFounder;

    // private GameObject enemyManager_2;

    public event EventHandler OnExperienceChangedNaujas;

    // [SerializeField] private LevelSystem levelSystem;

    // [SerializeField] private GameObject PfEnemyCanvas;

    [SerializeField] private GameObject LevelWindowGo;

    
    
    private int hitMax;
    private int hit;
    private void Awake() {
        healthAmount = healthAmountMax;
        
    }

    private void Start() {
        // enemyManager_2 = GameObject.Find("EnemyManager2");
        // enemyManager_2.GetComponent<EnemyManager_2>().OnLoadAllUnit += EnemyManager_2_OnLoadAllUnit;
    }

    private void Update() {
        // if(Input.GetKeyDown(KeyCode.M)) {
        //     GetComponent<HealthSystem>().Damage(15);
        // }
    }
    public void Damage( int damageAmount) {
        healthAmount -= damageAmount;
        // GetHealthAmount();
        // Debug.Log(GetHealthAmount());
        //healtamount between max and 0 ( not going be minus)
        healthAmount = Mathf.Clamp(healthAmount, 0 , healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);
        OnExperienceChangedNaujas?.Invoke(this, EventArgs.Empty);

        if(IsDead()) {
            OnDead?.Invoke(this, EventArgs.Empty);
            OnRemoveFromList?.Invoke(this, EventArgs.Empty);

        }

         if(IsDead2Unit()) {
            OnDead2?.Invoke(this, EventArgs.Empty);
            OnRemoveFromList2Unit?.Invoke(this, EventArgs.Empty);
        }

        
    }
    public bool IsDead() {
        return healthAmount == 0;
    }


    public bool IsDead2Unit() {
        return healthAmount == 0;
    }
    public int GetHealthAmount() {
        return healthAmount;
    }

    public int GetHealthAmountMax() {
        return healthAmountMax;
    }

    public float GetHealthAmountNormalized() {
        return (float)healthAmount / healthAmountMax;
    }

    public void SetHealthAmountMax (int healthAmountMax) {
        this.healthAmountMax = healthAmountMax;

        // if(updateHealthAmount) {
        //     healthAmount = healthAmountMax;
        // }
    }

    public void SetHealthAmount (int healthAmount) {
        this.healthAmount = healthAmount;
        // healthAmountMax++;

        // if(updateHealthAmount) {
        //     healthAmountMax = healthAmount;
        // }
    }


        // ISaveable implementation...
    //------------------------------------

    // Create a Serializable struct which contains all sorable data:
    // You don't need to save the location, rotation and scale, this will be done behind the scenes ;)
    [System.Serializable]
    struct HealthSystemData
    {
        public int healthAmount;
        public SaveableEntity.Vector3Data direction; // Use this vector type for unity Vector3
        // public float timePos;


        public int level;
        public int expierence;
    }
    
    public object SaveState()
    {
        return new HealthSystemData()
        {
            healthAmount = healthAmount,
            direction = new SaveableEntity.Vector3Data(transform.position),

            // level = LevelWindowGo.GetComponent<LevelWindowEnemy>().levelSystem.level,
            // expierence = LevelWindowGo.GetComponent<LevelWindowEnemy>().levelSystem.experience

            // level = PfEnemyCanvas.GetComponent<LevelWindowEnemy>().levelSystem.level,
            // expierence = PfEnemyCanvas.GetComponent<LevelWindowEnemy>().levelSystem.experience,
            // level = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level,
            // expierence = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience,
            // level = levelSystem.level,
            // expierence = levelSystem.experience,
            
            // timePos = timePos
        };
    }
    public void LoadState(object state)
    {
        HealthSystemData data = (HealthSystemData)state;
        healthAmount = data.healthAmount;
        transform.position = data.direction.ToVector3();


        // LevelWindowGo.GetComponent<LevelWindowEnemy>().levelSystem.level = data.level;
        // LevelWindowGo.GetComponent<LevelWindowEnemy>().levelSystem.experience = data.expierence;

        // PfEnemyCanvas.GetComponent<LevelWindowEnemy>().levelSystem.level = data.level;
        // PfEnemyCanvas.GetComponent<LevelWindowEnemy>().levelSystem.experience = data.expierence;
        // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level = data.level;
        // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience = data.expierence;

        // levelSystem.level = data.level;
        // levelSystem.experience = data.expierence;
        // timePos = data.timePos;
    }

    public bool NeedsToBeSaved()
    {
        return true;
    }
    public bool NeedsReinstantiation()
    {
        return true;
    }

    public void PostInstantiation(object state)
    {
        HealthSystemData data = (HealthSystemData)state;

    }
    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {

    }



}


