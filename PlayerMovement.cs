using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public GameObject enemy, missile;
    bool firstWave = true;
    bool realfirstWave = true;
    System.Random random = new System.Random();


    // Start is called before the first frame update


    //Ship Rotates 100 degrees per second when the keys are pressed and rotates 50 degrees per second back




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }


        int r = random.Next(-100, 100);
        if (realfirstWave)
        {
            


           Instantiate(enemy, new Vector3(0,0,250), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
           Instantiate(enemy, new Vector3(0 - 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
           Instantiate(enemy, new Vector3(0 - 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
           Instantiate(enemy, new Vector3(0 + 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
           Instantiate(enemy, new Vector3(0 + 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));


            realfirstWave = false;
        }

        if ((int)Time.realtimeSinceStartup % 7 == 0 && firstWave)
        {
            int x = random.Next(0, 4);
            if (x == 1)
            {
                Instantiate(enemy, new Vector3(r, 0, 250), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r - 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r - 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
            }
            else if (x == 2)
            {
                Instantiate(enemy, new Vector3(r, 0, 250), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r + 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r + 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
            }
            else
            {
                Instantiate(enemy, new Vector3(r, 0, 250), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r - 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r - 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r + 25, 0, 250 + 35), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
                Instantiate(enemy, new Vector3(r + 50, 0, 250 + 70), Quaternion.AngleAxis(180, new Vector3(0, 1, 0)));
            }

            
            firstWave = false;
        }
        if ((int)Time.realtimeSinceStartup % 7 == 1)
        {
            firstWave = true;
        }


        if (transform.position.x <= -190)
        {
            transform.position = new Vector3(-190, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 190f)
        {
            transform.position = new Vector3(190f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1f, 0, 0, Space.World);
            if (transform.rotation.z > -0.3f)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 100f);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1f, 0, 0, Space.World);
            if (transform.rotation.z < 0.3f)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 100f);
            }
        }

        if(transform.rotation.z > 0)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * 50f);
        }
        if (transform.rotation.z < 0)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 50f);
        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
