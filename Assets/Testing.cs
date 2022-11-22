using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private Enemy enemy;

    private void Awake() {
        LevelSystem levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
        //make same level system on enemy
        enemy.SetLevelSystem(levelSystem);
    }

}