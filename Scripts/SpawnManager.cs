using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos ;
    private float startDelay = 2;
    private float repeatrate = 0.9f;
    private PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatrate);
        player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefab.Length);
        float range = Random.Range(-12, 2);
        spawnPos = new Vector3(35, 0, range);
        if (player.gameOver == false)
        {
        Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);


        }
    }
}
