using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    // [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private Enemy enemy;

    [SerializeField] private LevelWindowEnemy levelWindow2;

    [SerializeField] private LevelWindow levelWindow;

    [SerializeField] private LevelWindowPlay levelWindowPlay;

    // [SerializeField] private Player player;

    // [SerializeField] private GameObject player;

    // [SerializeField] private Player [] players;

    [SerializeField] private Player player;

    private GameObject [] players;

    private void Awake() {
        LevelSystem levelSystem = new LevelSystem();

        

        // levelWindow.SetLevelSystem(levelSystem);
        levelWindowPlay.SetLevelSystem(levelSystem);

        player.SetLevelSystem(levelSystem);

        // player = GameObject.FindWithTag("Player1");
        // player.GetComponent<Player>().SetLevelSystem(levelSystem);
        // players.



        //make same level system on enemy
        // enemy.SetLevelSystem(levelSystem);
        // levelWindow2.SetLevelSystem(levelSystem);

    }

}
