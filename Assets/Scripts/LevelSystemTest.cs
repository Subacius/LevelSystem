using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// using SaveLoadSystem;

// [RequireComponent(typeof(SaveableEntity))]

public class LevelSystemTest: MonoBehaviour
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int [] expieriencePerLevel = new [] {100, 150, 200 , 250 , 300 , 350 , 400 , 450, 500 , 600};
    [SerializeField] public int level;
    [SerializeField] public int experience;
    // private int experienceToNextLevel;

    public LevelSystemTest() {
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



//    [System.Serializable]
//     struct LevelWindowSystemData
//     {



//         public int level;

//         public int expierence;
//     }
    
//     public object SaveState()
//     {
//         return new LevelWindowSystemData()
//         {

//             level = level,
//             expierence = experience
//             // level = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level,
//             // expierence = levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience,
//             // level = levelSystem.level,
//             // expierence = levelSystem.experience,
            
//             // timePos = timePos
//         };
        
//     }
//     public void LoadState(object state)
//     {
//         LevelWindowSystemData data = (LevelWindowSystemData)state;

//         level = data.level;
//         experience = data.expierence;

//         // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.level = data.level;
//         // levelWindowEnemy.GetComponent<LevelWindowEnemy>().levelSystem.experience = data.expierence;

//         // levelSystem.level = data.level;
//         // levelSystem.experience = data.expierence;
//         // timePos = data.timePos;
//     }

//     public bool NeedsToBeSaved()
//     {
//         return true;
//     }
//     public bool NeedsReinstantiation()
//     {
//         return true;
//     }

//     public void PostInstantiation(object state)
//     {
//         LevelWindowSystemData data = (LevelWindowSystemData)state;

//     }
//     public void GotAddedAsChild(GameObject obj, GameObject hisParent)
//     {

//     }
}
