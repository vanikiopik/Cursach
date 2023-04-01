using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponGUI : MonoBehaviour
{

    public WeaponController weaponController;
    private Text text;

    private void Awake()
    {
        weaponController.BulletChange += OnChangeBullets;
        text = GetComponent<Text>();
    }

    private void OnDestroy()
    {
        weaponController.BulletChange -= OnChangeBullets;
    }

    private void OnChangeBullets(int availableBullets, int bulletsInBag)
    {
        text.text = availableBullets.ToString() + "/" + bulletsInBag.ToString();
    }
}
