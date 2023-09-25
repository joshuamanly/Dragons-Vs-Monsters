using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreased;
    void Start()
    {
        scoreAmount = 0f;
        pointIncreased = 1f;
    }

    
    void Update()
    {
        scoreText.text = "Score : " +  (int)scoreAmount;
        scoreAmount += pointIncreased * Time.deltaTime;
    }
}
