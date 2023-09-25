using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //health, attackPower, moveSpeed
    public int health, attackPower;
    public float moveSpeed;

    public Animator animator;
    public float attackInterval;
    Coroutine attackOrder;
    Dragon detectedDragon;
     
    private void Update()
    {
        if (!detectedDragon)
        {
            Move();
        }    
    }

   IEnumerator Attack()
    {
        animator.Play("Attack",0,0);
        //wait attack interval
        yield return new WaitForSeconds(attackInterval);
        //attack again
        attackOrder = StartCoroutine(Attack());
    }
    //moving forward
    void Move()
    {
        animator.Play("Move");
        transform.Translate(-transform.right*moveSpeed*Time.deltaTime);
    }

    public void InflictDamage()
    {
        bool dragonDied = detectedDragon.LoseHealth(attackPower);

        if (dragonDied)
        {
            detectedDragon = null;
            StopCoroutine(attackOrder);
        }
    }
    //breaching the line
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Life")
        {
            Debug.Log("Lost health");
            GameManager.instance.lifeSystem.LoseLife();
            Destroy(gameObject);
        }

        if(detectedDragon) { return; }
        if(collision.tag == "Dragon")
        {
            detectedDragon = collision.GetComponent<Dragon>();  
            attackOrder = StartCoroutine(Attack());
        }
    }
    //lose health
    public void LoseHealth()
    {
        //Decrease health value
        health--;
        //blink red animation
        StartCoroutine(BlinkRed());
        //check if health is zero then destroy object
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.manaHandler.GainMana(1);
        }
    }

    IEnumerator BlinkRed()
    {
        //change the spriterender color to red
        GetComponent<SpriteRenderer>().color = Color.red;
        //wait for small amount of time
        yield return new WaitForSeconds(0.2f);
        //revert to default color
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
