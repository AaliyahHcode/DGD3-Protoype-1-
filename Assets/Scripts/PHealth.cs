using UnityEngine;
using UnityEngine.UI;

public class PHealth : MonoBehaviour
{
    public int health = 3;
    public int currentHealth;
    public Image[] imageOfHeart;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = health;
        Debug.Log("Player Current Health: " + currentHealth);
        rb = GetComponent<Rigidbody2D>();
        UpdateHeart();
    }

    public void TakeDamage(int damage, Vector2 knockback) //unity documentation
    {
        Debug.Log("Player got hit. Damage: "+ damage);
        currentHealth -= damage;
        //health cant go below zero
        currentHealth = Mathf.Max(currentHealth, 0); Debug.Log("Player health now: " + currentHealth);


        rb.AddForce(knockback, ForceMode2D.Impulse);
        Debug.Log("Player got knockedback");
        UpdateHeart();

        if(currentHealth <= 0) 
        {
            Debug.Log("Dead player");
            Die(); 
        }
    }
    void UpdateHeart()
    {
        for (int i = 0; i < imageOfHeart.Length; i++)
        {
            if (i < currentHealth) //got error caz right here had just health so it woukd never change
            {
                imageOfHeart[i].color = Color.red;
            }
            else
            {
                imageOfHeart[i].color = Color.gray;
            }
        }
    }

    void Die()
    {
        GameManagerMines.Instance.RespawnPlayer();
    }

    public void HealthReset() //restore hearts after respawn
    {
        currentHealth = health;
        UpdateHeart(); // heart image update
    }
}
