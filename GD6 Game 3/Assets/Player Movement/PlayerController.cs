using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MoveSpeed = 6;

    public Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    private GameObject drugs;


    // Start is called before the first frame update
    void Start()
    {

        SpawnDrugs();

    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }


    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Drugs"))
        {

            print("We took Drugs");

            Destroy(collision.gameObject);
            SpawnDrugs();

        }


        if(collision.tag == "Car")
        {
             



        }
  
        




    }

    private void SpawnDrugs()
    {

        bool drugsSpawned = false;
        while(!drugsSpawned)
        {

            Vector3 drugsPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
            if ((drugsPosition - transform.position).magnitude < 3)
            {

                continue;
            }
            else
            {

                Instantiate(drugs, drugsPosition, Quaternion.identity);
                drugsSpawned = true;
            }

        }


    }



}
