using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController player;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameOver==false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
        
    }
}
