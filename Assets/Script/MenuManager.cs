using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioClip backGroundMusic;

    private void Start()
    {
        SoundManager.Instance.PlayMusic(backGroundMusic);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Game");
        SoundManager.Instance.musicSource.Stop();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
