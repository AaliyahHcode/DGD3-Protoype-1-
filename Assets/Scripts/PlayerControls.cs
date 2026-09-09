using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float movespeed = 3f;
    private Rigidbody2D rb;
    private Vector2 move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * movespeed * Time.fixedDeltaTime);
    }
}
