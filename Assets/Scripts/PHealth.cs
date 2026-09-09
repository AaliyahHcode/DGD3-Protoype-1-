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
        rb = GetComponent<Rigidbody2D>();
        UpdateHeart();
    }

    public void TakeDamage(int damage, Vector2 knockback) //unity documentation
    {
        currentHealth -= damage;
        rb.AddForce(knockback, ForceMode2D.Impulse);
        UpdateHeart();

        if(currentHealth <= 0) { Die(); }
    }
    void UpdateHeart()
    {
        for (int i = 0; i < imageOfHeart.Length; i++)
        {
            if (i < health)
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
