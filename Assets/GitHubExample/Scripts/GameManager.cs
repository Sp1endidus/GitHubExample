using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    static bool playerExists;
    public static bool PlayerExists
    {
        get => playerExists;
        set
        {
            playerExists = value;

            if (!value)
            {
                Instance.Canvas.gameObject.SetActive(true);
            }
        }
    }
    public static GameObject Player;

    public Canvas Canvas;
    void Start()
    {
        Instance = this;
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerExists = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
