using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class PlayerManager : MonoBehaviour
{

    // public static BuildingManager Instance {get; private set;}
    private Camera mainCamera;
    private PlayerTypeListSO playerTypeList;
    private PlayerTypeSO playerType;

    // [SerializeField] private Building hqBuilding;


    private void Start () {
        mainCamera = Camera.main;
        // buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        playerTypeList = Resources.Load<PlayerTypeListSO>("PlayerTypeListSO");
        // buildingType = buildingTypeList.list[0];
        // Instantiate(buildingType.prefab, new Vector3(5, 2 , 0), Quaternion.identity);
        // Debug.Log("kazkas");
    }

    private void Update ( ){
        // if (Input.GetMouseButtonDown(0)) {
            // Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            // Vector3 enemySpawnPosition = GetMouseWorldPosition() + GetRandomDir() * 0.1f;
            // EnemyCM.Create(enemySpawnPosition);

        // }

        // if(Input.GetKeyDown(KeyCode.T)) {
        //     Vector3 enemySpawnPosition = GetMouseWorldPosition() + GetRandomDir() * 0.1f;
        //     EnemyCM.Create(enemySpawnPosition);
        // }

        // if(Input.GetKeyDown(KeyCode.Y)) {
        //     buildingType = buildingTypeList.list[1];
        // }


    }

    private Vector3 GetMouseWorldPosition() {
        Vector3 mousWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousWorldPosition.z = 0f;
        return mousWorldPosition;
    }

    public static Vector3 GetRandomDir() {
        return new Vector3( Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)).normalized;
    }

    // public Building GetHQBuilding () {
    //     return hqBuilding;
    // }
}
