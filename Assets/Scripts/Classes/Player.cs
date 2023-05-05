using System;
using UnityEngine.SceneManagement;

public class Player : Person
{

    public static event Action<float> HealthChanged;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0.1)
        {
            HealthChanged?.Invoke(0);
            Die();
        }
        else
            HealthChanged?.Invoke(_health); 
    }

    new void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
