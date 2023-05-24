using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;


public class AlienSpawn : MonoBehaviour
{
    public GameObject Alien;
    public GameObject LongRangeAlien;
    public GameObject CloseRangeAlien;

    [SerializeField]
    private float spawnRate;
    private float timer = 0;

    public Transform spawnParent;
    public Transform[] createAlienLine;

    void Awake()
    {
        RandomSpawnState();
        spawnAlien();
    }


    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnAlien();
            timer = 0;
        }
    }

    void spawnAlien()
    {
        int randomIndex = Random.Range(0, createAlienLine.Length);
        Transform selectedSpawn = createAlienLine[randomIndex];

        Vector3 spawnPosition = selectedSpawn.position;
        Quaternion spawnRotation = selectedSpawn.rotation;

        AlienType();
        Instantiate(Alien, spawnPosition, spawnRotation, spawnParent);
    }

    void AlienType()
    {
        int randomAlien = Random.Range(0, 2);

        if (randomAlien == 0)
        {
            Alien = LongRangeAlien;
        }
        else
        {
            Alien = CloseRangeAlien;
        }
    }

    void RandomSpawnState()
    {
        createAlienLine = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            createAlienLine[i] = transform.GetChild(i).transform;
        }
    }
}
