using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    [SerializeField] Text _text;

    private void Awake()
    {
        _text.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _text.enabled = true;
        StartCoroutine(BackToMainMenu());
    }

    IEnumerator BackToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
