using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public Rigidbody2D rb;

    float speed = 1f;

    public float MinSpeed = 8f;

    public float MaxSpeed = 12f;

    // Start is called before the first frame update
    void Start()
    {

    
        speed = Random.Range( MinSpeed, MaxSpeed);



    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 forward = new Vector2(transform.right.x,transform.right.y);

        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
             



    }







}
