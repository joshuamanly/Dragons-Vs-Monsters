using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    //The UI text for life count
    public Text txt_lifeCount;
    //defaukt value of life count
    public int defaultLifeCount;
    //current life count
    public int lifeCount;

    //Init the life system [reset the life count]
    public void Init()
    {
        lifeCount = defaultLifeCount;
        txt_lifeCount.text=lifeCount.ToString();
    }

    //lose life count
    public void LoseLife()
    {
        if (lifeCount < 1) return;

        lifeCount--;
        txt_lifeCount.text = lifeCount.ToString();

        CheckLifeCount();
    }
    
    //check life count for losing
    void CheckLifeCount()
    {
        if(lifeCount <= 0)
        {
            Debug.Log("You lost");
            //call some reset values and stop game from the manager
            Time.timeScale = 0;
            GameManager.instance.gameOverScreen.ShowScreen();
              
        }    
    }
}
