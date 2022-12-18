using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleStationExp : MonoBehaviour {

    [SerializeField] private GameObject [] allEnemies;

    [SerializeField] private GameObject [] allEnemiesSecond;

    private EnemyBattleStation enemyBattleStation;
    

    private void Awake() {
        // enemyBattleStation.GetComponent<EnemyBattleStation>();
    }

    private void Start() {

        // enemyBattleStation.GetComponent<EnemyBattleStation>().OnAddedEnemy += EnemyBattleStation_OnAddedEnemy;

        // if (allEnemies != null) {
        //     allEnemies = GameObject.FindGameObjectsWithTag("Enemy1");
        //     foreach (GameObject go in allEnemies) {
        //         LevelSystem levelSystem = new LevelSystem();
        //         go.transform.Find("PfEnemyCanvas").transform.Find("LevelWindow").GetComponent<LevelWindowEnemy>().SetLevelSystem(levelSystem);
        //         go.GetComponent<Enemy>().SetLevelSystem(levelSystem);
        //     }
        // }



    }

    private void EnemyBattleStation_OnAddedEnemy(object sender, EventArgs e)
    {
        LevelSystem levelSystem = new LevelSystem();

    }
}
