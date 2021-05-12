using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rigidbody;

    public float Speed;

    public float XReals;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float R = Mathf.Clamp(transform.position.x, -XReals, XReals);

        transform.position = new Vector3(R, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                rigidbody.velocity = Vector3.left * Speed;
            } 
            else
            {
                rigidbody.velocity = Vector3.right * Speed;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            GameManager.instance.GameOver();

            AdsManager.instance.ShowRewardedVideoAds();

        }
    }

}
