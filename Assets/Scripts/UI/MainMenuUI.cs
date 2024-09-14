using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public AudioSource clickSound;

    public float delayTimer;

    int index;

    public void StartButton()
    {
        index = 1;
        StartCoroutine(Delay());
    }

    public void GuideButton()
    {
        index = 2;
        StartCoroutine(Delay());
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator Delay()
    {
        clickSound.Play();

        yield return new WaitForSeconds(delayTimer);
        SceneManager.LoadScene(index);
    }
}
