using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Movment_MonoBehaviourScript : MonoBehaviour
{
    //variables
    public float speed;

    private Vector2 position;

    public GameManager gm;
    private SpriteRenderer color;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

        //set the color to the sprite renderer
        color = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Finding where we are located every frame and adding it to the vector we made
        position = transform.position;

        //if i press w I go up
        if (Input.GetKey(KeyCode.W))
        {
            position.y += speed * Time.deltaTime;
        }
        //if i presss S I go down
        if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed * Time.deltaTime;
        }
        //If i press A I go left
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed * Time.deltaTime;
        }
        //if i press D I go right
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
        }




        transform.position = position;
    }

    //on collision change the color of our square
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //sends a message to the console
        Debug.Log("hit");
        //randomly changes color upon collision
        color.color = Random.ColorHSV();
    }

    //destroy the collectable on trigger enter//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy whatever I run into
        Destroy(collision.gameObject);

        //recreate the object i just destroyed
        gm.Respawn();

        //randomly changes color upon collision
        color.color = Random.ColorHSV();
    }
}