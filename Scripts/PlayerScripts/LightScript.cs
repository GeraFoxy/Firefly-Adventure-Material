using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightScript : MonoBehaviour
{
    [Header("Light Settings")]
    public UnityEngine.Rendering.Universal.Light2D fireflyLight;
    [SerializeField] private float decreaseRate = 0.01f;
    [SerializeField] private float webDecreaseMultiplier = 5f;
    [SerializeField] private float minIntensity = 0.1f;
    [SerializeField] private float minOuterRadius = 0.5f;

    [Header("UI Settings")]
    public Image lightScaleImage;

    [Header("Game Settings")]
    public string loseSceneName = "GameScene";

    private float initialOuterRadius;
    private bool isInWeb = false;

    private void Start()
    {
        if (fireflyLight != null)
        {
            initialOuterRadius = fireflyLight.pointLightOuterRadius;
        }

        if (fireflyLight != null && lightScaleImage != null)
        {
            lightScaleImage.fillAmount = fireflyLight.intensity / 1f;
        }

        InvokeRepeating(nameof(DecreaseLight), 1f, 1f);
    }

    private void DecreaseLight()
    {
        if (fireflyLight == null || lightScaleImage == null) return;

        // Определяем текущую скорость уменьшения (обычная или в паутине)
        float currentDecreaseRate = isInWeb ? decreaseRate * webDecreaseMultiplier : decreaseRate;

        // Уменьшаем интенсивность света
        fireflyLight.intensity = Mathf.Max(minIntensity, fireflyLight.intensity - fireflyLight.intensity * currentDecreaseRate);

        // Уменьшаем радиус света (Outer Radius)
        fireflyLight.pointLightOuterRadius = Mathf.Max(minOuterRadius, fireflyLight.pointLightOuterRadius - initialOuterRadius * currentDecreaseRate);

        // Обновляем заполнение шкалы
        lightScaleImage.fillAmount = fireflyLight.intensity / 1f;

        // Проверяем, если свет упал до минимального значения
        if (fireflyLight.intensity <= minIntensity && fireflyLight.pointLightOuterRadius <= minOuterRadius)
        {
            TriggerLoseCondition();
        }
    }

    private void TriggerLoseCondition()
    {
        Debug.Log("Light has reached zero. You lose!");
        SceneManager.LoadScene(loseSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isInWeb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            isInWeb = false;
        }
    }
}
