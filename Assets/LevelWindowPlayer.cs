using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelWindowPlayer : MonoBehaviour
{

    public int maxExp;
    public float updatedExp;
    public Image Expbar;
    // public float expInreasePerSecond;

    public int playerLevel;

    public TMP_Text levelText;

    // public event EventHandler OnExperienceChangedNaujas;
    // [SerializeField] private WeaponPlayer weaponPlayer;

    // [SerializeField] private Player player;

    private GameObject enemyGameobject;

    // [SerializeField] private GameObject bandom;

    // [SerializeField] private InToEnemyCM inToEnemyCM;

    // [SerializeField] private HealthSystemPlayer healthSystemPlayer;
    // Start is called before the first frame update

    private void Awake() {
        // bandom = GetComponent<WeaponPlayer>().bulletPrefab;

        // bandom = GameObject.Find("pfRutulysInToEnemy(Clone)");
        enemyGameobject = GameObject.FindGameObjectWithTag("Enemy1");
    }
    void Start() {
        // weaponPlayer.OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;

        // weaponPlayer.bulletPrefab.GetComponent<InToEnemyCM>().OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;

        // bandom.GetComponent<InToEnemyCM>().OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;

        // bandom.GetComponent<WeaponPlayer>().bulletPrefab.GetComponent<InToEnemyCM>().OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;

        // player.OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;

        // enemyGameobject.GetComponent<Enemy>().OnExperienceChangedPlayer += WeaponPlayer_OnExpierenceChangedNaujas;



        // weaponPlayer = FindObjectOfType<WeaponPlayer>();
        playerLevel = 1;
        // expInreasePerSecond = 5f;
        maxExp = 25;
        updatedExp = 0;


        // healthSystemPlayer.OnExperienceChangedNaujas += HealthSystemPlayer_OnExpierenceChangedNaujas;

    }

    private void Update() {
        if(enemyGameobject != null) {
             enemyGameobject.GetComponent<Enemy>().OnExperienceChangedPlayer += WeaponPlayer_OnExpierenceChangedNaujas;
        }
    }

    private void WeaponPlayer_OnExpierenceChangedNaujas(object sender, EventArgs e) {
        Debug.Log("oooooooooooooooooo");
        updatedExp += 5f;
        Expbar.fillAmount = updatedExp / maxExp;

        levelText.text = "Lvl " + playerLevel;

        if (updatedExp >= maxExp) {
            playerLevel++;
            updatedExp=0;
            maxExp += maxExp;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     updatedExp += expInreasePerSecond * Time.deltaTime;
    //     Expbar.fillAmount = updatedExp / maxExp;

    //     levelText.text = "Lvl " + playerLevel;

    //     if (updatedExp >= maxExp) {
    //         playerLevel++;
    //         updatedExp=0;
    //         maxExp += maxExp;
    //     }
    // }

    // public void AddBandom() {
    //     // weaponPlayer = FindObjectOfType<WeaponPlayer>();
    //     weaponPlayer.OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;
    // }

    // private void WeaponPlayer_OnExpierenceChangedNaujas(object sender, EventArgs e)
    // {

    // }

    // public void AddExpTestNr1() {
    //     updatedExp += 5f;
    //     Expbar.fillAmount = updatedExp / maxExp;

    //     levelText.text = "Lvl " + playerLevel;

    //     if (updatedExp >= maxExp) {
    //         playerLevel++;
    //         updatedExp=0;
    //         maxExp += maxExp;
    //     }

    //     // OnExperienceChangedNaujas(this, EventArgs.Empty);
    // }
}
