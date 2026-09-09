using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public float durationofpowerup = 3f; //how long powerup lasts
    public float increaseSpeed = 3f; //add this much speed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //is the object that's touching the powerup, the player?
        {
            PlayerControls player = other.GetComponent<PlayerControls>();

            if (player != null)
            {
                player.StartCoroutine(SpeedBooster(player)); //start temp. speed booster
            }
            Destroy(gameObject); //remove power up after collection
        }
    }

    IEnumerator SpeedBooster(PlayerControls player)
    {
        float originalspeed = player.movespeed;
        player.movespeed += increaseSpeed;
        yield return new WaitForSeconds(durationofpowerup);
        player.movespeed = originalspeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
