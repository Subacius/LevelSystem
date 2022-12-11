using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PlayerType")]
public class PlayerTypeSO : ScriptableObject
{


    public string nameString;
    public Transform prefab;

    public Sprite sprite;

    public int healthAmountMax;

    public int hitMax;



}
