using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float offTime = 0.5f; 
    private float timer;

    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= offTime)
        {
            _light.enabled = !_light.enabled;
            timer = 0f;
        }
    }
}
