using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject creditMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("quit app");
    }

    public void CreditButton()
    {
        creditMenu.SetActive(true);
    }

    public void ExitCreditButton()
    {
        creditMenu.SetActive(false);
    }
}
