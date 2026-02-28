using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 1f;
    [SerializeField] private float lifetime = 1f;
    private TextMeshPro tmp;
    private float timer = 0f;

    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        Destroy(gameObject, lifetime);
    }

    public void SetDamage(float damage)
    {
        tmp = GetComponent<TextMeshPro>();
        tmp.text = "-" + Mathf.Round(damage).ToString();
    }

    void Update()
    {
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        float alpha = 1 - (timer / lifetime);
        tmp.color = new Color(1, 0, 0, alpha);
    }
}
