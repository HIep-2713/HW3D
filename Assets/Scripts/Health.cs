using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public Animator ani;
    public UnityEvent onDie;
    public UnityEvent<int, int> onHealthChange;
    public UnityEvent onTakeDamage;
    private int _healthPointValue;

    public int Healthpoint
    {
        get => _healthPointValue;
        set
        {
            int newValue = Mathf.Clamp(value, 0, maxHealthPoint);
            if (newValue == _healthPointValue) return;

            int oldHealth = _healthPointValue;
            _healthPointValue = newValue;

            onHealthChange?.Invoke(oldHealth, _healthPointValue);
        }
    }

    private bool IsDead => Healthpoint <= 0;

    private void Awake()
    {
        Healthpoint = maxHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Damage received: " + damage);
        if (IsDead) return;
        Healthpoint -= damage;
        onTakeDamage.Invoke();
        if (IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        onDie.Invoke();
    }
}
