using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AlienItem
{
    public string name;
    public int health;
    public int moveSpeed;
    public int attackRange;
    public int attackSpeed;
    public int damage;
    public bool isStun;
    public int stunTime;
    public GameObject Prefab; // Prefab
    public GameObject AttackPrefab; // Bullet Prefab
}

[CreateAssetMenu(fileName = "AlienSO", menuName = "Scriptable Object/Alien Item")]
public class AlienSO : ScriptableObject
{
    public AlienItem[] alienItems;
}
