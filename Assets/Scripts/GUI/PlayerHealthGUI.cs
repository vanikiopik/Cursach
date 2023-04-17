
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGUI : MonoBehaviour
{
    private Slider _hpBar;

    private void Awake()
    {
        Player.HealthChanged += OnHpChanged;
        _hpBar = GetComponent<Slider>();
    }

    private void OnDestroy()
    {
        Player.HealthChanged -= OnHpChanged;
    }

    private void OnHpChanged(float healthValue)
    {
        _hpBar.value = healthValue;
    }
}
