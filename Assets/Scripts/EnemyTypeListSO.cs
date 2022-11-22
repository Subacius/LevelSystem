using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/BuildingTypeList")]
public class EnemyTypeListSO : ScriptableObject
{
    public List<EnemyTypeSO> list;
}
