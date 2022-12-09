using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CodeMonkey;

public class HealthBarPlayer : MonoBehaviour {
    [SerializeField] private HealthSystemPlayer healthSystemPlayer;

    private Transform barTransform;

    private void Awake() {
        barTransform = transform.Find("bar");

    }

    private void Start() {
        healthSystemPlayer.OnDamaged += HealthSystem_OnDamaged;

        UpdateBar();
    }

    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.O)) {
    //         Save();
    //     }

    //     if(Input.GetKeyDown(KeyCode.P)) {
    //         Load();
    //     }
    // }

    private void HealthSystem_OnDamaged(object sender, System.EventArgs e) {
        UpdateBar();
    }


    public void UpdateBar() {
        barTransform.localScale = new Vector3(healthSystemPlayer.GetHealthAmountNormalized(), 1 ,1);
        // healthSystem.GetHealthAmount();
        // Debug.Log(healthSystem.GetHealthAmount());

    }



}
