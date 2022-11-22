using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerArrayList : MonoBehaviour {

    [SerializeField] public GameObject pfPlayer;

    [SerializeField] public GameObject pfPlayerNaujas;
    // [SerializeField] private GameObject pfEnemy2;
    public List<GameObject> primeGameObject = new List<GameObject>();

    void Awake() {

    }
    void Start()
    {
        // EventManager22 eventManager22 = GetComponent<EventManager22>();
        // eventManager22.OnClicked += EventManager22_OnClicked2;
    }
    // private void EventManager22_OnClicked2 (object sender, EventArgs e) {
    //     Debug.Log("boom");
    //     primeGameObject.Add(pfPlayer);

    // }


    void Update()
    {

    }

}
