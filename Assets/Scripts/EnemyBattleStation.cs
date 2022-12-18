using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SaveLoadSystem;
using System;

[RequireComponent(typeof(SaveableEntity))]

public class EnemyBattleStation : MonoBehaviour, ISaveable
{
    public List<GameObject> enemyBattleStationList1;

    [SerializeField] public GameObject pfEnemy1;

    // [SerializeField] public GameObject pfEnemy2;

    [SerializeField] private Transform enemyBattleStation;


    [SerializeField] public List<GameObject> addKitas;

    public event EventHandler OnAddedEnemy;

    private void Awake() {

    }

    private void Start() {
        enemyBattleStation.GetComponent<EnemyBattleStation>().OnAddedEnemy += EnemyBattleStation_OnAddedEnemy;
    }

    private void EnemyBattleStation_OnAddedEnemy(object sender, EventArgs e)
    {

        foreach (var item in enemyBattleStationList1) {
            LevelSystem levelSystem = new LevelSystem();
            item.transform.Find("PfEnemyCanvas").transform.Find("LevelWindow").GetComponent<LevelWindowEnemy>().SetLevelSystem(levelSystem);
            item.GetComponent<Enemy>().SetLevelSystem(levelSystem);
        }
    }

    public void AddPlayerUnitNaujas() {

        enemyBattleStationList1.Add(Instantiate(pfEnemy1, enemyBattleStation) as GameObject);

        pfEnemy1.GetComponent<SaveableEntity>().GenerateID();

        pfEnemy1.transform.position = new Vector3 (UnityEngine.Random.Range(-2.5f, 2.5f), UnityEngine.Random.Range(-4.2f, 4.2f), 0 ); 

        OnAddedEnemy?.Invoke(this, EventArgs.Empty);

    }

    // private void AddEnemyToList() {
    //     for (int i = 0; i < 2; i++)
    //     {
    //         // enemyBattleStationList1.Add(Instantiate(pfEnemy1, enemyBattleStation));
    //         Instantiate(pfEnemy1, enemyBattleStation);
    //         pfEnemy1.transform.position = new Vector3 (UnityEngine.Random.Range(-2.5f, 2.5f), UnityEngine.Random.Range(-4.2f, 4.2f), 0 );

    //     }
    // }
   //------------------------------------
    // ISaveable implementation...
    //------------------------------------

    // Create a Serializable struct which contains all sorable data:
    // You don't need to save the location, rotation and scale, this will be done behind the scenes ;)

    [System.Serializable]
    struct PlayerData
    {
        public List<string> enemyBattleStationList1;

        public List<string> addKitas;

    }
    public object SaveState()
    {

        List<string> gameObjects2 = new List<string>();
        foreach (GameObject go in addKitas)
        {
            gameObjects2.Add(go.GetComponent<SaveableEntity>().GetID());
            // Debug.Log(go.GetComponent<SaveableEntityBuilding>().GetID());

        }        

        List<string> gameObjects = new List<string>();
        foreach (GameObject go in enemyBattleStationList1)
        {
            gameObjects.Add(go.GetComponent<SaveableEntity>().GetID());
            // Debug.Log(go.GetComponent<SaveableEntityBuilding>().GetID());

        }
        // Instantiate the struct which contains the data we want to save and return it as object
        return new PlayerData()
        {
            enemyBattleStationList1 = gameObjects,
            addKitas = gameObjects2,
   
            // primeGameObject = primeGameObject,
            // tempDictionary = playerAmountDictionary,
        };
    }
    public void LoadState(object state)
    {
        PlayerData data = (PlayerData)state;
        
        

         // Receive a object which we need to
                                             // cast to extract our loaded data
        // this.primeGameObject = data.primeGameObject;
        // playerAmountDictionary = data.tempDictionary;
    }
    public bool NeedsToBeSaved()
    {
        // If this GameObject has a parent which also inherits from ISaveable,
        // than any return value of of childs will be ignored, because the parent will decide if the whole Object structure
        // gets saved or not.

        // Otherwise:
        // If true gets returned, this GameObject will be saved
        // If false gets returned, this GameObject will be ignored when saving
        return true;
    }

    // Return true, if this object needs to be reinstantiated at load or false if the loading is enough
    public bool NeedsReinstantiation()
    {
        return true;
    }
    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {
        // This function lets you know, that somewere deeper in the hirarchy of this GameObject a loaded GameObject got added to the structure
        // You may want to know that so you can setup the relations you may need

    }

    public void PostInstantiation(object state)
    {
        PlayerData data = (PlayerData)state; 
        

        // Receive a object which we need to cast to extract our loaded data
        // Will be called after all Objects got loaded and Parents of each Objects are set.
        // You may need to do stuff like in GotAddedAsChild(...) but with objects which are not childs of this
        // Then you do this stuff here, because here it is guaranteed, that all objects got Instantiated
        // You can find your target objects using:
        // SaveableEntity.FindID(string id) -> this will search all objects by the ID
        // just grab the .gameObject of the returned Object and use it
        // You may want to store the targets ID, so you can load back to the right object.
        // Call: obj.id on the SaveableEntity component of your target to get the ID

        List<string> gameObjects = data.enemyBattleStationList1;
        List<GameObject> foundEnemies = new List<GameObject>();
        foreach (string go in gameObjects)
        {
            // Search for Objects with a given ID
            SaveableEntity obj = SaveableEntity.FindID(go);
            if(obj)
            {
                // Found a anemy with the saved ID
                foundEnemies.Add(obj.gameObject);
                // Debug.Log("Player with ID: " + go + " found.");
            }
            else
            {
                // Debug.Log("No Player with ID: " + go + " found.");
            }
        }
        enemyBattleStationList1 = foundEnemies;


        List<string> gameObjects2 = data.addKitas;
        List<GameObject> foundEnemies2 = new List<GameObject>();
        
        foreach (string go in gameObjects2)
        {
            // Search for Objects with a given ID
            SaveableEntity obj = SaveableEntity.FindID(go);
            if(obj)
            {
                // Found a anemy with the saved ID
                foundEnemies2.Add(obj.gameObject);
                // Debug.Log("Player with ID: " + go + " found.");
            }
            else
            {
                // Debug.Log("No Player with ID: " + go + " found.");
            }
        }
        addKitas = foundEnemies2;

    }


}
