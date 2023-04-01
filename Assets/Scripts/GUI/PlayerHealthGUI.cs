
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGUI : MonoBehaviour
{
    private Slider _hpBar;

    [SerializeField] private Player _health;

    private void Awake()
    {
        _health.HealthChanged += OnHpChanged;
        _hpBar = GetComponent<Slider>();
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHpChanged;
    }

    private void OnHpChanged(float healthValue)
    {
        _hpBar.value = healthValue;
    }
}
