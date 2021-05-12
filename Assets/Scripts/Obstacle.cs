using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, 0, Speed * Time.deltaTime);

        if (transform.position.z < -8f)
        {
            
            GameManager.instance.UpdateScore();

            Destroy(gameObject);

        }

    }

}
