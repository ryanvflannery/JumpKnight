using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // assigning speed in all directions left, right, up, and down
        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);

        // Flip player when moving left and right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // if player presses space bar they will jump
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        // Set animator parameters left or right
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        // When space is pressed we will maintain the current velocity on the x axis 
        body.velocity = new Vector2(body.velocity.x, speed); // This will apply a velocity of 10 on the y axis
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
