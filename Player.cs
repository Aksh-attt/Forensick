using UnityEngine;

public class player : MonoBehaviour

{
    [SerializeField]
    public float speed = 5f; // Speed of the player movement
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 movement; // Variable to store player input
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }
     // Update is called once per frame
    void FixedUpdate()
    {
        // Move the player based on the input and speed
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
                // Get input from the horizontal and vertical axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void Update()
    {

    }

}
