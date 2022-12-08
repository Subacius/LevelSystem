using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Random=UnityEngine.Random;
// using SaveLoadSystemNaujas;

// namespace SaveLoadSystem

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    //galima isideti koki nori state
    [SerializeField] private BattleState state;

    [SerializeField] private GameObject [] playerList;

    // [SerializeField] private GameObject pftestArray;

    private GameObject findAllEnemyByEnemyManager;
    private GameObject [] findAllEnemyByTag;

    // private GameObject [] findAllEnemyByTag2;

    [SerializeField] private GameObject pfEnemyManagerBuilding1;

    [SerializeField] private GameObject [] enemyList;

    private GameObject [] AddToArrayEnemy;
    private GameObject [] AddToArrayEnemy2;

    private GameObject [] AddToArrayPlayer1;
    private GameObject [] AddToArrayPlayer2;

    private GameObject AddToArrayEnemyDestroy;
    [SerializeField] private Transform playerBattleStation;
    [SerializeField] public Transform enemyBattleStation;

    private PlayerTypeHolder playerTypeHolder;
    private EnemyTypeHolder enemyTypeHolder;

    [SerializeField] private TMP_Text damageText;

    public UnityEngine.UI.Button Button;
    public UnityEngine.UI.Button endButton;


    // public UnityEngine.UI.Button barrackButton;

    // private PlayerManagerAll playerManagerAll;

    // private EnemyManager_2 enemyManager_2;

    private GameObject pfEnemyBuildingCloneDestroy;

    //HP saving / loading
    // [SerializeField] private GameObject saveLoadSystem;

    // private SaveLoadSystem saveLoadSystem;

    private GameObject deleteAllEnemyFromList;

    // private DestroyAllEnemies destroyAllEnemies;

    private GameObject enemyManager2;

    private GameObject beforeBtn;

    bool isDead = false;

    [SerializeField] private LevelWindowPlay levelWindowPlay;

    // [SerializeField] private Player player;

    // private GameObject [] players;

    private void Awake() {

        LevelSystem levelSystem = new LevelSystem();

        foreach (GameObject go in playerList) {
            go.GetComponent<Player>().SetLevelSystem(levelSystem);
            Debug.Log(go.GetComponent<Player>());
            go.GetComponent<LevelWindowPlay>().SetLevelSystem(levelSystem);
            Debug.Log(go.GetComponent<LevelWindowPlay>());
        }

        // levelWindowPlay.SetLevelSystem(levelSystem);

        // player.SetLevelSystem(levelSystem);


        for ( int i = 0; i < playerList.Length; i++ ) {

            // testArray.primeGameObject[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 );
            GameObject playerGo = Instantiate(playerList[i], playerBattleStation);
            playerList[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 ); 
            // playerTypeHolder = playerGo.GetComponent<PlayerTypeHolder>();
        }


        for ( int i = 0; i < enemyList.Length; i++ ) {

            // testArray.primeGameObject[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 );
            GameObject enemyGo = Instantiate(enemyList[i], enemyBattleStation);
            enemyList[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 ); 
            // playerTypeHolder = enemyGo.GetComponent<PlayerTypeHolder>();
        } 

        // // SaveLoadSystem saveLoadSystem = saveLoadSystem.GetComponent<SaveLoadSystem>();
        //     enemyManager_2 = FindObjectOfType<EnemyManager_2>();
        //     playerManagerAll = FindObjectOfType<PlayerManagerAll>();
        //  if (playerManagerAll.primeGameObject.Count > 0) {
        //     //  Debug.Log("nenulis");
        //      endButton.gameObject.SetActive(false);


        //  } else {
        //     endButton.gameObject.SetActive(true);
        //     Button.gameObject.SetActive(false);

        //  }

        // pfEnemyBuildingCloneDestroy = GameObject.Find("pfEnemyBuilding(Clone)");


        // barrackButton.gameObject.SetActive(false);
    }
    private void Start() { 
        state = BattleState.START;
        
        StartCoroutine (SetupBattle());
  
    }

    private void Update() {

    }

    private IEnumerator SetupBattle() {

        // pftestArray = GameObject.FindGameObjectWithTag("Army");


        // PlayerManagerAll testArray = pftestArray.GetComponent<PlayerManagerAll>();
        




        // PlayerManagerAll testArray = pftestArray.GetComponent<PlayerManagerAll>();
        
        // for ( int i = 0; i < testArray.primeGameObject.Count; i++ ) {
        //     testArray.primeGameObject[i].transform.position = new Vector3 (-65 + Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 );
        //     // GameObject playerGo = Instantiate(testArray.primeGameObject[i], playerBattleStation);
        //     // playerTypeHolder = playerGo.GetComponent<PlayerTypeHolder>();
        // }

        //     SaveLoadSystem.saveName = "BattleSystem1.save";

        //     // string curFile = @"C:\Users\Egidijus\AppData\LocalLow\DefaultCompany\_SpaceStrategy\saves\BattleSystem1.save";
        //     string path = Application.persistentDataPath + "/saves/BattleSystem1.save";

        //     if ( File.Exists(path)) {
        //         Debug.Log("yra failas");
        //         SaveLoadSystem.saveName = "BattleSystem1.save";
        //         SaveLoadSystem.Load();

        //         if ( enemyManager2 != null) {
        //             enemyManager2 = GameObject.FindGameObjectWithTag("EnemyManager2");
        //             Destroy(enemyManager2.gameObject);
        //         }

        //     } else {
        //         Debug.Log("nera failo");

        //         findAllEnemyByEnemyManager = GameObject.FindGameObjectWithTag("EnemyBattleStation1");
        //         findAllEnemyByTag = GameObject.FindGameObjectsWithTag("Enemy1");
        // //         findAllEnemyByTag2 = GameObject.FindGameObjectsWithTag("Enemy2");

        //         for ( int i = 0; i <  findAllEnemyByEnemyManager.transform.childCount; i++ ) {

        //             GameObject enemyGo = Instantiate(findAllEnemyByTag[i], enemyBattleStation);
        //             enemyTypeHolder = enemyGo.GetComponent<EnemyTypeHolder>();
        //             findAllEnemyByTag[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 );

        //             // GameObject enemyGo2 = Instantiate(findAllEnemyByTag2[i], enemyBattleStation);
        //             // enemyTypeHolder = enemyGo2.GetComponent<EnemyTypeHolder>();
        //             // findAllEnemyByTag2[i].transform.position = new Vector3 ( Random.Range(-2.5f, 2.5f), Random.Range(-4.2f, 4.2f), 0 );
        //         }

        //         foreach ( GameObject go in findAllEnemyByTag) { 
        //             GameObject enemyGo = Instantiate(go, enemyBattleStation);
        //         }

        //         foreach(GameObject go2 in findAllEnemyByTag2) {
        //             GameObject enemyGo2 = Instantiate(go2, enemyBattleStation);
        //         }
        //         Debug.Log("pridedam unitus, bet ne is failo");
        //     }

 
        //isjungiau jeigu ka as pats

        // damageText.text = " The Battle gonna start : " + playerTypeHolder.playerType.nameString;

        yield return new WaitForSeconds(0.75f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    private IEnumerator PlayerAttack () {
        // ka pridejau veliausiai
        if (playerList != null) {
            playerList = GameObject.FindGameObjectsWithTag("Player1");

            foreach (GameObject player1 in playerList) {
            // Debug.Log(enemy1.transform.position.y);
            yield return new WaitForSeconds(0.5f);
            player1.GetComponent<WeaponPlayer>().Shoot();

        }

        // if (playerList != null) {
        // yield return new WaitForSeconds(0.5f);

        // playerList = GameObject.FindGameObjectsWithTag("Player2");

        //     foreach (GameObject player2 in playerList) {
        //     // Debug.Log(enemy1.transform.position.y);
        //     yield return new WaitForSeconds(0.1f);
        //     player2.GetComponent<WeaponPlayer2>().Shoot();

        //     }
        // }

        // damageText.text =  playerTypeHolder.playerType.nameString + " is attacking ";
        yield return new WaitForSeconds(2.5f);

        AddToArrayEnemy = GameObject.FindGameObjectsWithTag("Enemy1");
        // AddToArrayEnemy2 = GameObject.FindGameObjectsWithTag("Enemy2");

        if(AddToArrayEnemy.Length > 0) {
        // if(enemyBattleStation.GetComponentInChildren<HealthSystem>() != null ) {
        // if(enemyBattleStation.GetComponent<EnemyBattleStation>().enemyBattleStationList1.Count > 0) {
            // state = BattleState.WON;
            // EndBattle();
            isDead = false;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        } else {
            // state = BattleState.ENEMYTURN;
            // StartCoroutine(EnemyTurn());
            isDead = true;
            state = BattleState.WON;
            if(enemyBattleStation.childCount == 1) {
                Destroy(pfEnemyBuildingCloneDestroy);
                Debug.Log("Boom");

            }

            EndBattle();
            }
        }


    }

    private IEnumerator EnemyTurn() {
        // damageText.text = enemyTypeHolder.enemyType.nameString + " is attacking";

        yield return new WaitForSeconds(1.5f);

        if (enemyList != null) {
        
        enemyList = GameObject.FindGameObjectsWithTag("Enemy1");

            foreach (GameObject enemy1 in enemyList) {
                // Debug.Log(enemy1.transform.position.y);
                yield return new WaitForSeconds(0.1f);
                enemy1.GetComponent<WeaponEnemy>().Shoot();

            }
        }

        // if (enemyList != null) {
        // yield return new WaitForSeconds(0.5f);
        // enemyList = GameObject.FindGameObjectsWithTag("Enemy2");
        //     foreach (GameObject enemy2 in enemyList) {
        //         // Debug.Log(enemy2.transform.position.y);
        //         yield return new WaitForSeconds(0.1f);
        //         enemy2.GetComponent<WeaponEnemy2>().Shoot();

        //     }
        // }
        yield return new WaitForSeconds(3f);

        AddToArrayPlayer1 = GameObject.FindGameObjectsWithTag("Player1");
        // AddToArrayPlayer2 = GameObject.FindGameObjectsWithTag("Player2");

        // if(playerBattleStation.GetComponentInChildren<HealthSystem>() != null) {

        if(AddToArrayPlayer1.Length > 0 ||  AddToArrayPlayer2.Length > 0) {
            // state = BattleState.WON;
            // EndBattle();
            isDead = false;

            StartCoroutine(PlayerAttack());
        } else {
            // state = BattleState.ENEMYTURN;
            // StartCoroutine(EnemyTurn());
            isDead = true;
            state = BattleState.LOST;


            EndBattle();
            
        }        
    }

    private void EndBattle() {

        // destroyAllEnemies = FindObjectOfType<DestroyAllEnemies>();
        // destroyAllEnemies.DeleteAllEnemyplz(); 
        // destroyAllEnemies.DeleteAllEnemyplz2();

        
        // deleteAllEnemyFromList = GameObject.FindGameObjectWithTag("EnemyBattleStation1");
        // // deleteAllEnemyFromList.GetComponent<EnemyBattleStation>().enemyBattleStationList1.Clear();


        // SaveLoadSystem.saveName = "BattleSystem1.save";
        // Debug.Log(SaveLoadSystem.saveName + " save baby");
        // SaveLoadSystem.SaveNew();

        // if (state == BattleState.WON) {
        //     damageText.text = "You WON the battle!";
        //     // playerBattleStation.GetComponentInChildren<HealthSystem>().SavePlayer();
        //     // Debug.Log(playerBattleStation.GetComponentInChildren<HealthSystem>().healthAmount);


        // } else if (state == BattleState.LOST) {
        //     damageText.text = "You LOST the battle";
        // }

        // endButton.gameObject.SetActive(true);

    }

    private void PlayerTurn() { 

        // Debug.Log("aaa");

    }

    //through UI is should be marked as public
    public void OnAttackButton() {
        if ( state != BattleState.PLAYERTURN) {
            return;
        }

        StartCoroutine(PlayerAttack());
        Button.gameObject.SetActive(false);
         
    }

}
