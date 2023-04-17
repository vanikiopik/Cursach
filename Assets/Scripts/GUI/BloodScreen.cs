using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScreen : MonoBehaviour
{
    private const int _maxTransperency = 255;
    private const int _minTransepency = 0;
    private Color32 _color;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
        Player.HealthChanged += ChangeVisibility;
    }

    private void Start()
    {
        _color.a = _minTransepency;
        _image.color = _color;
    }

    public void Update()
    {

        if (_color.a > 3)
        {
            _color.a -= 1;
            _image.color = _color;
        }
        else if(_color.a < 2) return;
    }

    public void ChangeVisibility(float value)
    {
        _color.a = _maxTransperency;
    }

}
