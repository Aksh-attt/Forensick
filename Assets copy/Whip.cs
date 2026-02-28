using UnityEngine;

public class Whip : MonoBehaviour
{
    [SerializeField] private float whipRange = 3f;
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private float whipDamage = 34f;
    [SerializeField] private GameObject whipProjectilePrefab;

    private float lastAttackTime = 0f;
    private Camera cam;
    private LineRenderer lineRenderer;
    private float lineVisibleTime = 0.15f;
    private float lineTimer = 0f;
    private bool lineVisible = false;

    void Start()
    {
        cam = Camera.main;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }

        if (lineVisible)
        {
            lineTimer += Time.deltaTime;
            if (lineTimer >= lineVisibleTime)
            {
                lineRenderer.enabled = false;
                lineVisible = false;
                lineTimer = 0f;
            }
        }
    }

    void Attack()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 direction = (mousePos - playerPos).normalized;
        Vector2 endPoint = playerPos + direction * whipRange;

        // Line dikhao
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, playerPos);
        lineRenderer.SetPosition(1, endPoint);
        lineVisible = true;

        // Damage check
        RaycastHit2D hit = Physics2D.Raycast(playerPos + direction * 0.6f, direction, whipRange);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            EnemyHealth eh = hit.collider.GetComponent<EnemyHealth>();
            if (eh != null) eh.TakeDamage(whipDamage);
        }
    }
}