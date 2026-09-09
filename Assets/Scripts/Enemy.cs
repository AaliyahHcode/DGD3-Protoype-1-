using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1; //lose one heart/health
    public float knockbackForce = 2.5f;
    public float enemyMoveSpeed = 2.5f;
    private Rigidbody2D rb; //enemies rb

    //Detecting a player - how close does the player have to be
    //before they start getting chased by enemy and how far do they get to wander from spawn area
    public float detectionRange = 4f;
    public float wanderRange = 3.5f;

    //Wandering about the area; wait at the end of wander area before proceeding
    public float waittime = 1f;

    public Transform player;
    private Vector2 startingPosition; //enemy original spawn
    private Vector2 wanderToward; //location to wander to
    private float waittimer; //keep track of how long was waiting




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
