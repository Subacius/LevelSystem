using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int XPToNextLevel = 100;

    public event EventHandler OnDamaged;

    public void AddXP(int amount)
    {
        currentXP += amount;

        if(currentXP >= XPToNextLevel)
        {
            currentLevel++;
            currentXP -= XPToNextLevel;
            XPToNextLevel *= 2;
        }
    }




    public float GetHealthAmountNormalized() {
        return (float)currentXP / XPToNextLevel;
    }
}
