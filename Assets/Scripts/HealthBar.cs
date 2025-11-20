using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealValue;
    public Health health;
    public float smoothSpeed = 0.5f;

    private float targetFill;

    void Start()
    {
        targetFill = (float)health.Healthpoint / health.maxHealthPoint;
        HealValue.fillAmount = targetFill;
        health.onHealthChange.AddListener(OnHealthChanged);
    }

    void Update()
    {
        if (HealValue.fillAmount != targetFill)
        {
            HealValue.fillAmount = Mathf.MoveTowards(
                HealValue.fillAmount,
                targetFill,
                smoothSpeed * Time.deltaTime
            );
        }
    }

    private void OnHealthChanged(int oldHealth, int newHealth)
    {
        targetFill = (float)newHealth / health.maxHealthPoint;
    }
}
