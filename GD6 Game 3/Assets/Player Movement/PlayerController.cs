using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public AudioClip die;
    public AudioClip mushroom_eating;

    public float MoveSpeed = 6;

    public Rigidbody2D rb;

    Vector2 movement;

    public int maxHealth = 4;

    public int currentHealth;

    public HealthBar healthBar;



    [SerializeField]
    private GameObject drugs;


    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);


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

            print("We Collided with Drugs");

            SoundManager.Instance.PlayMusic(mushroom_eating);

            Destroy(collision.gameObject);
            SpawnDrugs();

            Pickup();
           

        }


        if(collision.tag == "Car")
        {

            TakeDamage(1);

            SoundManager.Instance.PlayMusic(die);

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



    void TakeDamage(int damage)
    {


        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

           

            print("Game Over");


        }


    }


    void Pickup()
    {

        print("We Got The Effects of Taking Drugs");

        MoveSpeed = -6;



    }


}
