using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private EnemyHealthBar healthBar;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (damageTextPrefab != null)
        {
            GameObject txt = Instantiate(damageTextPrefab,
                transform.position + Vector3.up * 0.5f, Quaternion.identity);
            txt.GetComponent<DamageText>().SetDamage(damage);
        }

        if (healthBar != null)
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}