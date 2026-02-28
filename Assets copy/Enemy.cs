using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float damagePerSecond = 10f;
    
    private Transform player;
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        isChasing = distance < detectionRadius;
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damagePerSecond * Time.fixedDeltaTime);
        }
    }
}