using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    private PlayerTypeSO playerType;
    private HealthSystemPlayer healthSystem;
    // private HealthSystem2 healthSystem2;
    private GameObject pftestArray;
    [SerializeField] private GameObject particalEffects;

    private PlayerManagerAll playerManagerAll;

    // private PlayerPanel1Txt playerPanelTxt;

    // private PlayerPanel2Txt playerPanel2Txt;

    // public event EventHandler OnExperienceChangedNaujas;



    public string nameName;


    private void Awake () {
        PlayerTypeListSO playerTypeList = Resources.Load<PlayerTypeListSO>(typeof(PlayerTypeListSO).Name);
        // SaveSystemNew.players.Add(this);


    }
    private void Start() {

        playerType = GetComponent<PlayerTypeHolder>().playerType;
        healthSystem = GetComponent<HealthSystemPlayer>();

        // healthSystem.SetHealthAmountMax(playerType.healthAmountMax, true);



        


        // healthSystem.SetHealthAmountMax2(playerType.healthAmountMax, true);
        
        // healthSystem.SetHealthCurrent(healthSystem.healthAmount);
        // Debug.Log(healthSystem.GetHealthAmount());
        // healthSystem.SetHealthCurrent(healthSystem.GetHealthAmount());
        // healthSystem.GetHealthAmountNormalized();
        // Debug.Log(healthSystem.GetHealthAmountNormalized());

        // healthSystem.GetHealthAmount();
        // Debug.Log(healthSystem.GetHealthAmount());

        healthSystem.OnDead += HealthSystem_OnDied;

        healthSystem.OnRemoveFromList += HealthSystem_OnRemoveFromList;

        playerManagerAll = FindObjectOfType<PlayerManagerAll>();

        // playerPanelTxt = FindObjectOfType<PlayerPanel1Txt>();

        // playerPanel2Txt = FindObjectOfType<PlayerPanel2Txt>();

    }


    private void Update() {

    }
    private void HealthSystem_OnDied(object sender, System.EventArgs e) {

        Destroy(gameObject);

        // OnExperienceChangedNaujas?.Invoke(this, EventArgs.Empty);

        Instantiate(particalEffects, gameObject.transform.position, Quaternion.identity);
        particalEffects = GameObject.Find("Explosion VFX(Clone)");
        Destroy(particalEffects.gameObject, 1f);

    }

    // private void HealthSystem_OnRemoveFromList (object sender, EventArgs e) {
    //     PlayerTypeListSO playerTypeList = Resources.Load<PlayerTypeListSO>(typeof(PlayerTypeListSO).Name);
    //     pftestArray = GameObject.FindGameObjectWithTag("Army");
    //     PlayerManagerAll testArray = pftestArray.GetComponent<PlayerManagerAll>();
    
    //     testArray.primeGameObject.Remove(testArray.pfPlayer);
    //     playerManagerAll.RemovePlayerUnit(playerTypeList.list[0], 1);

    //     playerPanelTxt.RemoveCounter();


    // }


    private void HealthSystem_OnRemoveFromList (object sender, EventArgs e) {
        PlayerTypeListSO playerTypeList = Resources.Load<PlayerTypeListSO>(typeof(PlayerTypeListSO).Name);
        pftestArray = GameObject.FindGameObjectWithTag("Army");
        PlayerManagerAll testArray = pftestArray.GetComponent<PlayerManagerAll>();

        
    
        testArray.primeGameObject.Remove(gameObject);
        playerManagerAll.RemovePlayerUnit(playerTypeList.list[0], 1);
        // remove from Panel1
        // playerPanelTxt.RemoveCounter();


    }




}
