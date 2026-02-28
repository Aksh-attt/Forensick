using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    private EnemyHealth enemyHealth;
    private Camera cam;

    void Start()
    {
        enemyHealth = GetComponentInParent<EnemyHealth>();
        cam = Camera.main;
    }

    void Update()
    {
        // Health bar enemy ke upar rahe, camera face kare
        transform.rotation = cam.transform.rotation;
    }

    public void UpdateHealthBar(float current, float max)
    {
        healthBarFill.fillAmount = current / max;
    }
}