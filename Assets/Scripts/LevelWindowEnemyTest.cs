using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using TMPro;
// using SaveLoadSystem;

// [RequireComponent(typeof(SaveableEntity))]

public class LevelWindowEnemyTest : MonoBehaviour {

    [SerializeField] private TMP_Text levelText;

    [SerializeField] private Image expierenceBarImage;
    // private Image expierenceBarImage;
    // [SerializeField] private LevelSystemTest levelSystem;

    // [SerializeField] private float expExp;

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int [] expieriencePerLevel = new [] {100, 150, 200 , 250 , 300 , 350 , 400 , 450, 500 , 600};
    [SerializeField] public int level;
    [SerializeField] public int experience;


    private void Awake() {

        // expExp = 0;
        // levelText = transform.Find("levelText").GetComponent<Text>();
        // levelText = GameObject.Find("levelText").GetComponent<Text>();
        // Debug.Log(levelText);
        // expierenceBarImage = transform.Find("expierenceBar").Find("bar").GetComponent<Image>();
        // expierenceBarImage = GameObject.Find("bar");
        // SetLevelNumber(7);
        // SetExpierenceBarSize(0.5f);

        // transform.Find("expAdd5exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(7);
        // transform.Find("expierenceBtn50Exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(52);
        // transform.Find("expierenceBtn500Exp").GetComponent<Button_UI>().ClickFunc = () => levelSystem.AddExperience(455);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            // GetComponent<HealthSystem>().Damage(15);
            // levelSystem.AddExperience(25);
            AddExperience(27);
            Debug.Log("paspaudžiau");
        }
    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////

    public void AddExperience (int amount) {
        if (!IsMaxLevel()) {
        //+= increase exp
        experience += amount;
        while (!IsMaxLevel() && experience>= GetExpierenceToNextLevel(level)) {
            experience -= GetExpierenceToNextLevel(level);
            level++;

            if(OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExpierenceNormalized() {

        if (IsMaxLevel()) {
            return 1f;
        } else {
            return (float)experience / GetExpierenceToNextLevel(level);
        }

    }

    public int GetExpierenceToNextLevel (int level) {
        if (level < expieriencePerLevel.Length) {
            return expieriencePerLevel[level];
        } else {
            Debug.LogError("Level invalid: " + level);
            return 100;
        }
    }

    public bool IsMaxLevel() {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel (int level) {
        return level == expieriencePerLevel.Length - 1;
    }

    /////////////////////////////////////////////////////////////////////

    private void SetExpierenceBarSize( float expierenceNormalized) {
        // expierenceBarImage.GetComponent<Image>();
        expierenceBarImage.fillAmount = expierenceNormalized;
    }

    // private void SetExpierenceBarSize( float expExp) {
    //     // expierenceBarImage.GetComponent<Image>();
    //     // expExp = this.expExp;
    //     expierenceBarImage.fillAmount = expExp;
    //     Debug.Log(expExp);
    // }

    private void SetLevelNumber( int levelNumber) {
        levelText.text = "Lvl " + (levelNumber + 1);
        // Debug.Log(levelText.text);
    }

    // public void SetLevelSystem(LevelSystemTest levelSystem) {
    //     //Set the Level Object
    //     this.levelSystem = levelSystem;
    //     //Update the starting values
    //     SetLevelNumber(levelSystem.GetLevelNumber());
    //     SetExpierenceBarSize(levelSystem.GetExpierenceNormalized());
    //     //Subscribe to the changed events
    //     levelSystem.OnExperienceChanged += LevelSystem_OnExpierenceChanged;
    //     levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        
    // }


    public void SetLevelSystem() {
        //Set the Level Object
        // this.levelSystem = levelSystem;
        //Update the starting values
        SetLevelNumber(GetLevelNumber());
        SetExpierenceBarSize(GetExpierenceNormalized());
        //Subscribe to the changed events
        OnExperienceChanged += LevelSystem_OnExpierenceChanged;
        OnLevelChanged += LevelSystem_OnLevelChanged;
        
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e) {
        //Level Changed, update text
        SetLevelNumber(GetLevelNumber());
    }

    private void LevelSystem_OnExpierenceChanged(object sender, EventArgs e) {
        //Expierence changed, update bar size
        SetExpierenceBarSize(GetExpierenceNormalized());
    }

    // public void AddExpToButton() {
    //     levelSystem.AddExperience(7);
    // }



        // ISaveable implementation...
    //------------------------------------

    // Create a Serializable struct which contains all sorable data:
    // You don't need to save the location, rotation and scale, this will be done behind the scenes ;)
    // [System.Serializable]
    // struct LevelWindowSystemData
    // {

    //     public int level;
    //     public int expierence;



    // }
    
    // public object SaveState()
    // {
    //     return new LevelWindowSystemData()
    //     {


    //         level = levelSystem.level,
    //         expierence = levelSystem.experience
    //         // level = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level,
    //         // expierence = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience,
    //         // level = levelSystem.level,
    //         // expierence = levelSystem.experience,
            
    //         // timePos = timePos
    //     };
        
    // }
    // public void LoadState(object state)
    // {
    //     LevelWindowSystemData data = (LevelWindowSystemData)state;
        

    //     levelSystem.level = data.level;
    //     levelSystem.experience = data.expierence;

    //     // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level = data.level;
    //     // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience = data.expierence;

    //     // levelSystem.level = data.level;
    //     // levelSystem.experience = data.expierence;
    //     // timePos = data.timePos;
    // }

    // public bool NeedsToBeSaved()
    // {
    //     return true;
    // }
    // public bool NeedsReinstantiation()
    // {
    //     return true;
    // }

    // public void PostInstantiation(object state)
    // {
    //     LevelWindowSystemData data = (LevelWindowSystemData)state;

    // }
    // public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    // {

    // }

}
