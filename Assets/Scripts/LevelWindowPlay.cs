using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;

public class LevelWindowPlay : MonoBehaviour {

    [SerializeField] private TMP_Text levelText;

    [SerializeField] private Image expierenceBarImage;
    // private Image expierenceBarImage;
    private LevelSystem levelSystem;

    private WeaponPlayer weaponPlayer;
    private void Awake() {

    }

    private void SetExpierenceBarSize( float expierenceNormalized) {
        // expierenceBarImage.GetComponent<Image>();
        expierenceBarImage.fillAmount = expierenceNormalized;
    }

    private void SetLevelNumber( int levelNumber) {
        levelText.text = "Lvl " + (levelNumber + 1);
        // Debug.Log(levelText.text);
    }

    public void SetLevelSystem(LevelSystem levelSystem) {
        //Set the Level Object
        this.levelSystem = levelSystem;
        //Update the starting values
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExpierenceBarSize(levelSystem.GetExpierenceNormalized());
        //Subscribe to the changed events
        levelSystem.OnExperienceChanged += LevelSystem_OnExpierenceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e) {
        //Level Changed, update text
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExpierenceChanged(object sender, EventArgs e) {
        //Expierence changed, update bar size
        // weaponPlayer.Boom += WeaponPlayer_Boom;
        SetExpierenceBarSize(levelSystem.GetExpierenceNormalized());
    }

    // private void WeaponPlayer_Boom(object sender, EventArgs e)
    // {
    //     levelSystem.AddExperience(7);
    // }
}
