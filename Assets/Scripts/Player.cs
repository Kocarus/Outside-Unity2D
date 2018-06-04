using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    //Floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {   

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //Scale when moving (can be used for eating an item)
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }          
        }

    }

    void FixedUpdate()
    {

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f; //z axis is not used in 2D game
        easeVelocity.x *= 0.75f; //reduce the velocity.x

        float h = Input.GetAxis("Horizontal");

        //Fake friction / Easing the x speed of our player
        if (grounded)
        {

            rb2d.velocity = easeVelocity;

        }

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        //Limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

}