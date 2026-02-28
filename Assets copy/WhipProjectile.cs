using UnityEngine;

public class WhipProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float damage = 34f;
    [SerializeField] private float lifetime = 0.3f;
    
    private Vector2 direction;

public void SetDirection(Vector2 dir)
{
    direction = dir.normalized;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0, 0, angle);
    Destroy(gameObject, lifetime);
}

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            if (eh != null)
            {
                eh.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}