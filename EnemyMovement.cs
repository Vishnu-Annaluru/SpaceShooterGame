using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject enemy;
   
    int z;
    int r;


    float timeAlive;
    System.Random random = new System.Random();


    void Start()
    {
        r = random.Next(-20, 20) * 2;
        z = random.Next(-25, 20) * 2;
        timeAlive = Time.realtimeSinceStartup;
        //enemy1 = Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
        //StartCoroutine(makeWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= 0f) //|| transform.position.x <= -200f || transform.position.x >=200f || transform.position.z > 250f
        {
            Destroy(gameObject);
        }

        if(Time.realtimeSinceStartup - timeAlive < 5)
        {
            transform.Translate(0, 0, 25 * Time.deltaTime);

            
        }
        else
        {

            
            transform.Translate((r * 2) * Time.deltaTime, 0, z * Time.deltaTime);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }











}
