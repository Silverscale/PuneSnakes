using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "New Avatar Type")]
public class AvatarTypeSO : ScriptableObject
{
    public string typeName;
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public Sprite sprite;
    
}
