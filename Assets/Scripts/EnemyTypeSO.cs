using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/BuildingType")]
public class EnemyTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefab;

    public int healthAmountMax;

    public int hitMax;
}
