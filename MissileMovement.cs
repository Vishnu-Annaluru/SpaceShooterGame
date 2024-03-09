using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    public Text text;
    float timeAlive;
    int score = 0;
    int z = 30;

    void Start()
    {
        timeAlive = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 250)
        {
            Destroy(gameObject);
        }
        if(Time.realtimeSinceStartup - timeAlive < 1)
        {
            z = -10;
        }
        else
        {
            z = 30;
        }
        transform.Translate(0, 0, z * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        score++;
        text.text = "Score: " + score;
        ps = Instantiate(ps, transform.position, Quaternion.identity);
        
    }

}


