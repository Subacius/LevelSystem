using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnits : MonoBehaviour {

    private Camera mainCamera;
    private PlayerTypeListSO playerTypeList;
    private PlayerTypeSO playerType;

    private void Start() {
        mainCamera = Camera.main;
        playerTypeList = Resources.Load<PlayerTypeListSO>("PlayerTypeListSO");
        playerType = playerTypeList.list[0];
        Instantiate(playerType.prefab, new Vector3(-5, 2 , 0), Quaternion.identity);
        Instantiate(playerType.prefab, new Vector3(-7, 3 , 0), Quaternion.identity);
        Instantiate(playerType.prefab, new Vector3(-6, -4 , 0), Quaternion.identity);
        // buildingType = buildingTypeList.list[1];
        // Instantiate(buildingType.prefab, new Vector3(4, 1, 0), Quaternion.identity);

        //random pozicijas pametyti gal for loop prasukti?
    }

}
