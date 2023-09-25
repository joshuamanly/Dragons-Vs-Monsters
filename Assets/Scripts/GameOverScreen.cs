using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void ShowScreen()
    {
        gameObject.SetActive(true);
    }

   public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
