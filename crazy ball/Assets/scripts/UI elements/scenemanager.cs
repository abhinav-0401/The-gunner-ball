using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenemanager : MonoBehaviour
{
    public GameObject confirmation_screen;
    [SerializeField] AudioClip click_sound;
    public void MainMenuButton()
    {
        MusicManager.instance.Play(click_sound);
        SceneManager.LoadScene(1);
    }
    public void GamePlayButton()
    {
        MusicManager.instance.Play(click_sound);
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        MusicManager.instance.Play(click_sound);
        SceneManager.LoadScene(0);
    }
    public void QuitButton()
    {
        MusicManager.instance.Play(click_sound);
        LeanTween.moveLocalY(confirmation_screen, 0f, 1f).setEaseOutElastic();
    }

    public void CancelButton()
    {
        MusicManager.instance.Play(click_sound);
        LeanTween.moveLocalY(confirmation_screen, -800f, 1f).setEaseOutElastic();
    }
    public void FinalQuitButton()
    {
        print("App is closed now");
        Application.Quit();
    }
}
