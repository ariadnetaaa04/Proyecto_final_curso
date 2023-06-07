using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 playerPosition;
    private int score;
    public GameObject player;

    // Call this method to save the game state
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerZ", playerPosition.z);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    // Call this method to load the saved game state
    public void LoadGame()
    {
        playerPosition = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        score = PlayerPrefs.GetInt("Score");
        player.transform.position = playerPosition;
    }
}
