using UnityEngine;

public class Exit : MonoBehaviour
{
    public float pulseSpeed = 2.5f;
    public float pulsequantity = 0.02f; //how much pulsating (big to small)
    private Vector3 originalscale; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalscale = transform.localScale; //save initial
    }

    // Update is called once per frame
    void Update()
    {
        float pulse = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulsequantity; //from stack overflow (gentle pulse)
        transform.localScale = originalscale * pulse;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManagerMines.Instance.Win();
        }
    }
}
