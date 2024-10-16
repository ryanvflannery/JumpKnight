using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

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
        if (Input.GetKey(KeyCode.Space))
            // When space is pressed we will maintain the current velocity on the x axis
            // This will apply a velocity of 10 on the y axis
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
