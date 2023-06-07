using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AstronautItem
{
    public string name;
    public int health;
    public int cost;
    public int moveSpeed;
    public int attackRange;
    public int attackSpeed;
    public int damage;
    public bool isPenetrate;
    public bool isDot;
    public int dotDamage;
    public int dotTime;
    public GameObject Prefab; // Prefab
    public GameObject BulletPrefab; // Bullet Prefab
}

// public class BulletItem
// {
//     public int attackRange;
//     public int attackSpeed;
//     public int damage;
//     public bool isPenetrate;
//     public bool isDot;
//     public int dotDamage;
//     public int dotTime;
//     public GameObject Prefab; // Bullet Prefab
// }

[CreateAssetMenu(fileName = "AstronautSO", menuName = "Scriptable Object/Astronaut Item")]
public class AstronautSO : ScriptableObject
{
    public AstronautItem[] astronautItems;
}