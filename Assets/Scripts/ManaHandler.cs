using UnityEngine;
using UnityEngine.UI;

public class ManaHandler : MonoBehaviour
{
    public Image manaBar;
    public Text manaText;

    public float myMana;
    private float currentMana;
    
    void Start()
    {
        currentMana = myMana; 
        currentMana = 10;
    }

    void Update()
    {
        if (currentMana < myMana)
        {
            manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount,1f,Time.deltaTime * 0.02f);
            currentMana = Mathf.MoveTowards(currentMana / myMana, 1f, Time.deltaTime * 0.02f) * myMana;
        }

        if(currentMana < 0)
        {
            currentMana = 0;
        }
        if (currentMana > 30)
        {
            currentMana = 30;
        }

        manaText.text = "" + Mathf.FloorToInt(currentMana);
    }
    public void GainMana(float mana)
    {
        currentMana += mana;
        manaBar.fillAmount += mana / myMana;
    }
     
    public bool EnoughMana(float mana)
    {
        if (mana <= currentMana) return true;
        else return false;
    }
    public void ReduceMana(float mana)
    {
        if(EnoughMana(mana))
        {
            currentMana -= mana;
            manaBar.fillAmount -= mana / myMana;
        }
    }
}
