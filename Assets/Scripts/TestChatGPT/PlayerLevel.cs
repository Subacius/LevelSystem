using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveLoadSystem;
using TMPro;

[RequireComponent(typeof(SaveableEntity))]

public class PlayerLevel : MonoBehaviour, ISaveable
{
    public int level = 1;

    public int maxLevel = 5;
    public int experience = 0;
    public int experienceToNextLevel = 100;
    public Slider experienceBar;

    public TextMeshProUGUI levelText;
    // public string playerID;

    // private Vector3 position;

    void Start()
    {
        // experienceBar.maxValue = experienceToNextLevel;
        /////
        // playerID = System.Guid.NewGuid().ToString();
        // Load();
        /////
        // playerID = PlayerPrefs.GetString("playerID", "");
        //     if(playerID=="")
        //     {
        //         playerID = System.Guid.NewGuid().ToString();
        //         PlayerPrefs.SetString("playerID", playerID);
        //     }
        // Load();
    }

    void Update()
    {
        if (level >= maxLevel)
        {
        return; // exit the method, the player cannot level up anymore
        }

        if (experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            experienceToNextLevel *= 2;
            experienceBar.maxValue = experienceToNextLevel;
        }
        ExpierenceBarValue();
        levelText.SetText("Lvl: " + level);

        if (Input.GetKeyDown(KeyCode.M)) {
            AddExperience(155);
            Debug.Log("bbuu");
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            ExpierenceBarValue();
            Debug.Log("ccec?");

        }

    }

    public void AddExperience(int amount)
    {
        if (level < maxLevel)
        {
            experience += amount;
        }
    } 

    public void ExpierenceBarValue() {
        experienceBar.maxValue = experienceToNextLevel;
        experienceBar.value = experience;
    }

    // public void Save()
    // {
    //     PlayerPrefs.SetString(playerID + "_positionX", transform.position.x.ToString());
    //     PlayerPrefs.SetString(playerID + "_positionY", transform.position.y.ToString());
    //     PlayerPrefs.SetString(playerID + "_positionZ", transform.position.z.ToString());

    //     PlayerPrefs.SetInt(playerID+"level", level);
    //     PlayerPrefs.SetInt(playerID+"experience", experience);
    //     PlayerPrefs.SetInt(playerID+"experienceToNextLevel", experienceToNextLevel);
    //     PlayerPrefs.Save();
    //     Debug.Log("Saved!");
    // }

    // public void Load()
    // {
    //     float x = float.Parse(PlayerPrefs.GetString(playerID + "_positionX", "0"));
    //     float y = float.Parse(PlayerPrefs.GetString(playerID + "_positionY", "0"));
    //     float z = float.Parse(PlayerPrefs.GetString(playerID + "_positionZ", "0"));
    //     transform.position = new Vector3(x, y, z);
    

    //     level = PlayerPrefs.GetInt(playerID+"level", 1);
    //     experience = PlayerPrefs.GetInt(playerID+"experience", 0);
    //     experienceToNextLevel = PlayerPrefs.GetInt(playerID+"experienceToNextLevel", 100);
    //     experienceBar.maxValue = experienceToNextLevel;
    //     experienceBar.value = experience;
    //     Debug.Log("Loaded!");
    // }

[System.Serializable]
    struct ExperienceSystemData
    {
        public int level;

        public int experience;

        public int experienceToNextLevel;
    }
    
    public object SaveState()
    {
        return new ExperienceSystemData()
        {
            level = level,
            experience = experience,
            experienceToNextLevel = experienceToNextLevel

        };
    }
    public void LoadState(object state)
    {
        ExperienceSystemData data = (ExperienceSystemData)state;
        level = data.level;
        experience = data.experience;
        experienceToNextLevel = data.experienceToNextLevel;

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
        ExperienceSystemData data = (ExperienceSystemData)state;

    }
    public void GotAddedAsChild(GameObject obj, GameObject hisParent)
    {

    }


}
