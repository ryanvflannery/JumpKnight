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
        // assigning speed in all directions left, right, up, and down
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // if player presses space bar they will jump
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
