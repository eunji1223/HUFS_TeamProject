using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;


public class AlienSpawn : MonoBehaviour
{
    [SerializeField]
    private AlienSO alienSO;
    private GameObject Alien; // Randomly selected Alien

    [SerializeField]
    private float spawnRate;
    private float timer;

    [SerializeField]
    private Text timer_min;

    public Transform spawnParent;
    private Transform[] createAlienLine;

    void Awake()
    {
        timer = 0;
        RandomSpawnState();
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

        spawnRate -= Time.deltaTime * 0.02f;
    }

    void spawnAlien()
    {
        int randomIndex = Random.Range(0, createAlienLine.Length);

        Transform selectedSpawn = createAlienLine[randomIndex];

        Vector3 spawnPosition = selectedSpawn.position;
        spawnPosition.z -= 1;
        Quaternion spawnRotation = selectedSpawn.rotation;

        AlienType();
        Instantiate(Alien, spawnPosition, spawnRotation);
    }

    void AlienType()
    {
        int randomAlien = Random.Range(0, alienSO.alienItems.Length-1);
        if (Int32.Parse(timer_min.text) >= 2 && randomAlien==2) {
            randomAlien = 0;
        }
        if (randomAlien>=3) {
            randomAlien+= 1;
        }

        Alien = alienSO.alienItems[randomAlien].Prefab;
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
