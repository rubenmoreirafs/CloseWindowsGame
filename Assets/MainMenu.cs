
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    public void PlayGame() {

        clickSound.Play();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame() {

        clickSound.Play();
        SceneManager.LoadSceneAsync(0);
    }
}
