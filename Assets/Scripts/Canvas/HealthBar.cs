using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillImage;

    public void SetHealth(float healthPercentage)
    {
        if (healthPercentage <= slider.maxValue)
            slider.value = healthPercentage;
        else if (healthPercentage >= 0)
            slider.value = healthPercentage;
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fillImage.color = gradient.Evaluate(1F);
    }
}