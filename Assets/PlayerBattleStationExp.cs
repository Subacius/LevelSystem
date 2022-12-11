using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleStationExp : MonoBehaviour {

    [SerializeField] private GameObject [] allPlayers;

    [SerializeField] private GameObject [] allPlayersSecond;

    private void Start() {

        if (allPlayers != null) {
            allPlayers = GameObject.FindGameObjectsWithTag("Player1");
        }
        // if (allPlayersSecond != null) {
        //     allPlayersSecond = GameObject.FindGameObjectsWithTag("Player2");
        // }


        if (allPlayers != null) {
            foreach (GameObject go in allPlayers) {
                LevelSystem levelSystem = new LevelSystem();
                go.transform.Find("PfPlayerCanvas").transform.Find("LevelWindowPlayer").GetComponent<LevelWindowPlay>().SetLevelSystem(levelSystem);
                go.GetComponent<Player>().SetLevelSystem(levelSystem);
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
