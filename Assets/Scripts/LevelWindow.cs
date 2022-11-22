using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelWindow : MonoBehaviour {

    [SerializeField] private Text levelText;

    [SerializeField] private Image expierenceBarImage;
    // private Image expierenceBarImage;
    private LevelSystem levelSystem;
    private void Awake() {
        // levelText = transform.Find("levelText").GetComponent<Text>();
        // levelText = GameObject.Find("levelText").GetComponent<Text>();
        // Debug.Log(levelText);
        // expierenceBarImage = transform.Find("expierenceBar").Find("bar").GetComponent<Image>();
        // expierenceBarImage = GameObject.Find("bar");
        // SetLevelNumber(7);
        // SetExpierenceBarSize(0.5f);
        transform.Find("expierenceBtn5Exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(5);
        transform.Find("expierenceBtn50Exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(52);
        transform.Find("expierenceBtn500Exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(455);
    }

    private void SetExpierenceBarSize( float expierenceNormalized) {
        // expierenceBarImage.GetComponent<Image>();
        expierenceBarImage.fillAmount = expierenceNormalized;
    }

    private void SetLevelNumber( int levelNumber) {
        levelText.text = "LEVEL" + (levelNumber + 1);
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
        SetExpierenceBarSize(levelSystem.GetExpierenceNormalized());
    }
}
