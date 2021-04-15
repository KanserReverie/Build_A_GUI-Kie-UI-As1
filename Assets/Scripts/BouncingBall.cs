using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Rigidbody rb;
    private float time;
    public float force;
    private float bounceTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bounceTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= bounceTime)
        {
            rb.AddForce(0, force, 0);
            time = 0;
            bounceTime = Random.Range(2.8f, 3.0f);
        }
    }
}
