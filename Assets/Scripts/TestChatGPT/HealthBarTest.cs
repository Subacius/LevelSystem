using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
// using CodeMonkey;

public class HealthBarTest : MonoBehaviour {
    [SerializeField] private PlayerLevel playerLevel;

    private Transform barTransform;

    // private IUnit222 unit;




    private void Awake() {
        barTransform = transform.Find("bar");
    }

    private void Start() {
        playerLevel.OnDamaged += HealthSystem_OnDamaged;

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
        barTransform.localScale = new Vector3(playerLevel.GetHealthAmountNormalized(), 1 ,1);
        // healthSystem.GetHealthAmount();
        // Debug.Log(healthSystem.GetHealthAmount());

    }

}
