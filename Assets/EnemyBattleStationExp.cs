using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattleStationExp : MonoBehaviour {

    [SerializeField] private GameObject [] allEnemies;

    [SerializeField] private GameObject [] allEnemiesSecond;

    private void Start() {

        if (allEnemies != null) {
            allEnemies = GameObject.FindGameObjectsWithTag("Enemy1");
        }
        // if (allPlayersSecond != null) {
        //     allPlayersSecond = GameObject.FindGameObjectsWithTag("Player2");
        // }


        if (allEnemies != null) {
            foreach (GameObject go in allEnemies) {
                LevelSystem levelSystem = new LevelSystem();
                go.transform.Find("PfEnemyCanvas").transform.Find("LevelWindow").GetComponent<LevelWindowEnemy>().SetLevelSystem(levelSystem);
                go.GetComponent<Enemy>().SetLevelSystem(levelSystem);
            }

        }

        // if (allPlayersSecond != null) {
        //     foreach (GameObject go in allPlayersSecond) {
        //         LevelSystem levelSystem = new LevelSystem();
        //         go.transform.Find("PfPlayerCanvas").transform.Find("LevelWindowPlayer").GetComponent<LevelWindowPlay>().SetLevelSystem(levelSystem);
        //         go.GetComponent<Player>().SetLevelSystem(levelSystem);
        //     }

        // }


    }
}
