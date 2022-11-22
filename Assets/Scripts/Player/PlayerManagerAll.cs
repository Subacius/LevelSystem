using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;





public class PlayerManagerAll : MonoBehaviour
{
    //singleton pattern  // static instante field  // in Awake nepamirstan Instance = this;
    public static PlayerManagerAll Instance {get; private set;}
    private Dictionary<PlayerTypeSO, int> playerAmountDictionary;


    public event EventHandler OnResourceAmountChanged;

    public event EventHandler OnResourceAmountChangedNaujas;

    public event EventHandler OnResourceAmountChangedRemove;

    public event EventHandler OnResourceAmountChangedNaujasRemove;

    public List<GameObject> primeGameObject = new List<GameObject>();

    // [SerializeField] private GameObject [] enemies;
    // private PlayerArrayList playerArrayList;

    [SerializeField] public GameObject pfPlayer;

    [SerializeField] public GameObject pfPlayerNaujas;

    [SerializeField] private Transform playerManagerTransform;

    private void Awake()
    {
        Instance = this;
        playerAmountDictionary = new Dictionary<PlayerTypeSO, int>();

        PlayerTypeListSO playerTypeList = Resources.Load<PlayerTypeListSO>(typeof(PlayerTypeListSO).Name);

        foreach (PlayerTypeSO playerType in playerTypeList.list)
        {
            playerAmountDictionary[playerType] = 0;
        }
        
    }

    private void Start() {

    }

    public void AddPlayerUnit(PlayerTypeSO playerType, int amount)
    {
        playerAmountDictionary[playerType] += amount;
        // pfPlayer.GetComponent<SaveableEntityBuilding>().GenerateID();

        primeGameObject.Add(Instantiate(pfPlayer, playerManagerTransform));

        // primeGameObject.Add[playerType] += amount;
        //?.Invoke patikrina ar ne null 
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddPlayerUnitNaujas(PlayerTypeSO playerType, int amount)
    {
        playerAmountDictionary[playerType] += amount;
        // pfPlayerNaujas.GetComponent<SaveableEntityBuilding>().GenerateID();
        // primeGameObject.Add(pfPlayerNaujas);
        primeGameObject.Add(Instantiate(pfPlayerNaujas, playerManagerTransform));
        // primeGameObject.Add[playerType] += amount;
        //?.Invoke patikrina ar ne null 
        OnResourceAmountChangedNaujas?.Invoke(this, EventArgs.Empty);
    }

    public void RemovePlayerUnit(PlayerTypeSO playerType, int amount)
    {
        playerAmountDictionary[playerType] -= amount;
        Debug.Log("Remove player: " + amount);
        //isemiau, nes 2 kart minusuodavo
        // primeGameObject.Remove(pfPlayer);
        //?.Invoke patikrina ar ne null 
        OnResourceAmountChangedRemove?.Invoke(this, EventArgs.Empty);
    }

    public void RemovePlayerUnitNaujas(PlayerTypeSO playerType2, int amount)
    {
        playerAmountDictionary[playerType2] -= amount;
        //isemiau, nes 2 kart minusuodavo
        // primeGameObject.Remove(pfPlayerNaujas);
        //?.Invoke patikrina ar ne null 
        OnResourceAmountChangedNaujasRemove?.Invoke(this, EventArgs.Empty);
    }

    public int GetPlayerAmount(PlayerTypeSO playerType) {
        return playerAmountDictionary[playerType];
    }

    // //------------------------------------
    // // ISaveable implementation...
    // //------------------------------------

    // // Create a Serializable struct which contains all sorable data:
    // // You don't need to save the location, rotation and scale, this will be done behind the scenes ;)

    // [System.Serializable]
    // struct WariorObject
    // {
    //     public string name;
    //     public int amount;
    // }
    // [System.Serializable]
    // struct PlayerData
    // {
    //     public List<string> primeGameObject;
    //     public List<WariorObject> wariors;

    // }
    // public object SaveState()
    // {

    //     List<WariorObject> wariorsToSave = new List<WariorObject>();
    //     foreach(var res in playerAmountDictionary)
    //     {
    //         WariorObject obj;
    //         obj.name = res.Key.nameString;
    //         obj.amount = res.Value;
    //         wariorsToSave.Add(obj);
    //     }

    //     List<string> gameObjects = new List<string>();
    //     foreach (GameObject go in primeGameObject)
    //     {
    //         gameObjects.Add(go.GetComponent<SaveableEntityBuilding>().GetID());
    //         // Debug.Log(go.GetComponent<SaveableEntityBuilding>().GetID());

    //     }
    //     // Instantiate the struct which contains the data we want to save and return it as object
    //     return new PlayerData()
    //     {
    //         primeGameObject = gameObjects,
    //         wariors = wariorsToSave
    //         // primeGameObject = primeGameObject,
    //         // tempDictionary = playerAmountDictionary,
    //     };
    // }
    // public void LoadState(object state)
    // {
    //     PlayerData data = (PlayerData)state;
        
        
    //     List<WariorObject> wariorsToLoad = data.wariors;
    //         for (int i = 0; i < wariorsToLoad.Count; ++i)
    //         {
    //         foreach (var res in playerAmountDictionary)
    //         {
    //             if (res.Key.nameString == wariorsToLoad[i].name)
    //             {
    //                 playerAmountDictionary[res.Key] = wariorsToLoad[i].amount;
    //                 goto nextElem;
    //             }
    //         }
    //         nextElem:;
    //     }
    //      // Receive a object which we need to
    //                                          // cast to extract our loaded data
    //     // this.primeGameObject = data.primeGameObject;
    //     // playerAmountDictionary = data.tempDictionary;
    // }
    // public bool NeedsToBeSaved()
    // {
    //     // If this GameObject has a parent which also inherits from ISaveable,
    //     // than any return value of of childs will be ignored, because the parent will decide if the whole Object structure
    //     // gets saved or not.

    //     // Otherwise:
    //     // If true gets returned, this GameObject will be saved
    //     // If false gets returned, this GameObject will be ignored when saving
    //     return true;
    // }

    // // Return true, if this object needs to be reinstantiated at load or false if the loading is enough
    // public bool NeedsReinstantiation()
    // {
    //     return true;
    // }
    // public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    // {
    //     // This function lets you know, that somewere deeper in the hirarchy of this GameObject a loaded GameObject got added to the structure
    //     // You may want to know that so you can setup the relations you may need

    // }

    // public void PostInstantiation(object state)
    // {
    //     PlayerData data = (PlayerData)state; 
        
    //     WariorsUI.UpdateWariorAmount();
    //     // Receive a object which we need to cast to extract our loaded data
    //     // Will be called after all Objects got loaded and Parents of each Objects are set.
    //     // You may need to do stuff like in GotAddedAsChild(...) but with objects which are not childs of this
    //     // Then you do this stuff here, because here it is guaranteed, that all objects got Instantiated
    //     // You can find your target objects using:
    //     // SaveableEntity.FindID(string id) -> this will search all objects by the ID
    //     // just grab the .gameObject of the returned Object and use it
    //     // You may want to store the targets ID, so you can load back to the right object.
    //     // Call: obj.id on the SaveableEntity component of your target to get the ID

    //     List<string> gameObjects = data.primeGameObject;
    //     List<GameObject> foundEnemies = new List<GameObject>();
    //     foreach (string go in gameObjects)
    //     {
    //         // Search for Objects with a given ID
    //         SaveableEntityBuilding obj = SaveableEntityBuilding.FindID(go);
    //         if(obj)
    //         {
    //             // Found a anemy with the saved ID
    //             foundEnemies.Add(obj.gameObject);
    //             // Debug.Log("Player with ID: " + go + " found.");
    //         }
    //         else
    //         {
    //             // Debug.Log("No Player with ID: " + go + " found.");
    //         }
    //     }
    //     primeGameObject = foundEnemies;

    // }


}
