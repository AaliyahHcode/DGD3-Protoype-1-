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
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        NewWanderTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToThePlayer = Vector2.Distance(rb.position, player.position);
        //after enemy finds distance to the player then chase the player if they are close enough
        if (distanceToThePlayer <= detectionRange)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, player.position, enemyMoveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition); //rb2d to move btter for physics and barriers
        }
        else
        {
            Wander();
        }
    }

    void Wander()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, wanderToward, enemyMoveSpeed * Time.fixedDeltaTime);

        rb.MovePosition(newPosition); //use rb to move
        if (Vector2.Distance(rb.position, wanderToward) < 0.1f) //has the enemy reached wadrer destination
        {
            waittimer += Time.fixedDeltaTime;//count how long the wait

            if(waittimer >= waittime) //when time is over choose another location
            {
                NewWanderTarget();
                waittimer = 0f; //reset timer
            }
        }
    }

    void NewWanderTarget()
    {
        Vector2 randomDirection = Random.insideUnitCircle * wanderRange;//choosing a random point in the wander area
        wanderToward = startingPosition + randomDirection; //enemy wander in it's own area in  a random direction from original spot
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PHealth health = collision.gameObject.GetComponent<PHealth>();
            if (health != null)
            {
                Vector2 direction = (collision.transform.position - transform.position).normalized;
                health.TakeDamage(damage, direction * knockbackForce);
            }
        }
    }
}
