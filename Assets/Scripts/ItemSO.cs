using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name; // 이름
    public int health; // 체력
    public int damage; // 공격력
    public int hitType;
    // BlueGun : 기본(0), GreenGun : 데미지 2배(1), YellowGun : 관통(2), RedGun: 불(지속뎀)(3), Slow: 속도 느리게(4), Bomb: 폭탄(5), Wall: 방패병(6)
    public int maxDistance; // 공격 범위
    // 총 이용 시만 사용, Bomb, Wall 제외
    public float regenTime; // 총알 생성 시간
    public float gunSpeed; // 총알 속도
    public GameObject AstroPre; // Prefab
    public GameObject bulletPre; // bullet prefab
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
