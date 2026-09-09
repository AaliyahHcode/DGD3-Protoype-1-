using UnityEngine;

public class GameManagerMines : MonoBehaviour
{

    public static GameManagerMines Instance;
    public Transform startpoint;
    public GameObject player;

    public GameObject explode;
    public GameObject winText;

    private void Awake()
    {
        Instance = this; //accesible to other scripts
    }
    public void RespawnPlayer()
    {
        if (explode != null) //create explosion, player dead
        {
            Instantiate(explode, player.transform.position, Quaternion.identity);
        }

        player.transform.position = startpoint.position; //move back to start point
        PHealth health = player.GetComponent<PHealth>(); // go into health script
        health.HealthReset(); //restore the hearts
    }

    public void Win()
    {
        Debug.Log("You survived!");
        if (winText != null)
        {
            winText.SetActive(true);
        }
        Time.timeScale = 0; //stop game
    }
}


