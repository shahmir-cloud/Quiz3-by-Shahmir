using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour
{
    public bool isparent=true;
    private float speed = 20;
    private GameObject player;

    GameManager gamem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gamem = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isparent)
        {
            
            transform.position = player.transform.position + new Vector3(0, 0.2f, 0); ;

        }
        else
        {
            
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isparent = true;
            gamem.score += 25;
        }
        else if (col.gameObject.CompareTag("Animal"))
        {
            Debug.Log("I am collided with an animal");
            Destroy(gameObject);
            isparent = false;
        }
        else if (col.gameObject.CompareTag("obstical"))
        {
            Debug.Log("I am collided with an animal");
            Destroy(gameObject);
            isparent = false;
        }
    }
    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            isparent = false;
        }
    }
}
