using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DarknessManager : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private float timeToFullDark = 120f;
    private float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        float alpha = Mathf.Clamp01(elapsed / timeToFullDark);
        globalLight.intensity = 1f - alpha;
    }
}