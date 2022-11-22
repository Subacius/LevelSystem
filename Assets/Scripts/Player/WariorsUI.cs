using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using SaveLoadSystemBuildingName;
using System.IO;



// [RequireComponent(typeof(SaveableEntityBuilding))]


public class WariorsUI : MonoBehaviour {

    // private ResourceTypeListSO resourceTypeList;

    [SerializeField] WariorUIElement wariorTemplate;
    [SerializeField] float offsetAmount = 80;

    public static WariorsUI Instance { get; private set; }

    [SerializeField] private GameObject pfPlayer1;
    [SerializeField] private GameObject pfPlayer2;



    private PlayerTypeListSO playerTypeListSO;

    private Dictionary<PlayerTypeSO, WariorUIElement> uiWariorDictionary;

    // private GameObject getAmountOfWarior;

    // // public List<GameObject> wariorCounting = new List<GameObject>();
    // public List<GameObject> primeGameObject = new List<GameObject>();

    // private GameObject [] addToList;

    // private GameObject addToListOneByOne;

    // public string fileName = "dict.bin";

    // string dictPath { get { return Application.dataPath + "/" + fileName; } }
    // private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;

    // [SerializeField] private Transform resourceTemplate;


    // private static ResourcesUI myself = null;

    // public TMP_Text text;
    private void Awake()
    {

        Instance = this;

        
        // addToList = GameObject.Find("aa");

        playerTypeListSO = Resources.Load<PlayerTypeListSO>(typeof(PlayerTypeListSO).Name);

        uiWariorDictionary = new Dictionary<PlayerTypeSO, WariorUIElement>();

        // wariorTypeTransformDictionary = new Dictionary<PlayerTypeSO, Transform>();
        // Transform wariorTemplate = transform.Find("wariorTemplate");
        // wariorTemplate.gameObject.SetActive(false);


        int index = 0;
        foreach (PlayerTypeSO wariorType in playerTypeListSO.list){
            // findWariorTemplate.GetComponent<SaveableEntityBuilding>().GenerateID();

            WariorUIElement wariorTransform = Instantiate(wariorTemplate, transform);
            // wariorCounting.Add(wariorTemplate)

            wariorTransform.gameObject.SetActive(true);
            float offsetAmount = 80f;
            // wariorTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);
            // wariorTransform.Find("image").GetComponent<Image>().sprite = wariorType.sprite;
            wariorTransform.SetPosition(new Vector2(offsetAmount * index, 0));
            wariorTransform.SetImage(wariorType.sprite);

            uiWariorDictionary[wariorType] = wariorTransform;
            index ++;
            // findWariorTemplate = GameObject.Find("wariorTemplate(Clone)");
            // wariorCounting.Add(findWariorTemplate);


        }

    }

    // private void Update() {
    //     // if (Input.GetKeyDown(KeyCode.N)) {
    //     //     Debug.Log("Test N raide");
    //     // }
    //        text.GetComponent<TextMeshProUGUI>().SetText(mNumber.ToString());
    // }
    // private int mNumber = 0;
    // public void SetNumber(int number) {
    //     mNumber += number;
    //     // text.GetComponent<TextMeshProUGUI>().SetText(mNumber.ToString());

    // }


    private void Start(){
        // DontDestroyOnLoad(gameObject);

            PlayerManagerAll.Instance.OnResourceAmountChanged += PlayerManagerAll_OnResourceAmountChanged;
            PlayerManagerAll.Instance.OnResourceAmountChangedNaujas += PlayerManagerAll_OnResourceAmountChangedNaujas;

            PlayerManagerAll.Instance.OnResourceAmountChangedRemove += PlayerManagerAll_OnResourceAmountChanged;
            PlayerManagerAll.Instance.OnResourceAmountChangedNaujasRemove += PlayerManagerAll_OnResourceAmountChangedNaujas;
            UpdateWariorAmount();


        // string path = Application.persistentDataPath + "/saves/Building.save";
        // // Debug.Log(path + " path");
        // // Debug.Log(File.Exists(path) + " exits");

        //     if ( !File.Exists(path)) {
        //         // Debug.Log("yra failas " + path);
        //         UpdateResourceAmount();

        //     } 


        
        // UpdateResourceAmount();

        // Debug.Log(gameObjectText);
        // // DontDestroyOnLoad(gameObject);
        // Debug.Log(gameObjectText.GetComponent<TMPro.TextMeshProUGUI>().text);
        // gameObjectText.GetComponent<Text>().text;


    }

    private void PlayerManagerAll_OnResourceAmountChanged(object sender, System.EventArgs e){
        UpdateWariorAmount();
    }

    private void PlayerManagerAll_OnResourceAmountChangedNaujas(object sender, System.EventArgs e){
        UpdateWariorAmount();
    }

    // public void UpdateResourceAmount(){
        
    //     foreach (PlayerTypeSO wariorType in playerTypeListSO.list){
    //         // Debug.Log(wariorType);

    //         Transform wariorTransform = wariorTypeTransformDictionary[wariorType];
    //         int resourceAmount = PlayerManagerAll.Instance.GetResourceAmount(wariorType);
    //         // Debug.Log(resourceAmount  + " amount wariors");
    //         wariorTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
    //     }
    // }

    public static void UpdateWariorAmount()
    {
        if (!Instance) return;
        foreach (PlayerTypeSO playerType in Instance.playerTypeListSO.list){

            if(Instance.uiWariorDictionary.ContainsKey(playerType))
            {
                //Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
                WariorUIElement wariorTransform = Instance.uiWariorDictionary[playerType];
                int wariorAmount = PlayerManagerAll.Instance.GetPlayerAmount(playerType);
                // Debug.Log(resourceAmount + " resource amount tikrinam");
                //if(resourceTransform)
                //    resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
                if (wariorTransform)
                    wariorTransform.SetText(wariorAmount.ToString());
            }
            else
            {
                Debug.LogWarning("Key: " + playerType.name + " does not exist in the table: wariorTypeTransformDictionary");
            }
            
        }
    }

    public static void UpdateWariorAmount(PlayerTypeSO playerType, int amount)
    {
        if (!Instance) return;
        if(Instance.uiWariorDictionary.ContainsKey(playerType))
        {
            WariorUIElement uiElement = Instance.uiWariorDictionary[playerType];
            if (uiElement)
                uiElement.SetText(amount.ToString());
        }
    }




}
