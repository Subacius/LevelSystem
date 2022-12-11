using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int [] expieriencePerLevel = new [] {100, 150, 200 , 250 , 300 , 350 , 400 , 450, 500 , 600};
    private int level;
    private int experience;
    // private int experienceToNextLevel;

    public LevelSystem() {
        level = 0;
        experience = 0;
        // experienceToNextLevel = 100;
    }

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
}
