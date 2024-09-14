using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScreen : MonoBehaviour
{
    public AudioSource clickSound;

    public float delayTimer;

    int index;

    public void PlayAgainButton()
    {
        index = 1;
        StartCoroutine(Delay());
    }

    public void MainMenuButton()
    {
        index = 0;
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
