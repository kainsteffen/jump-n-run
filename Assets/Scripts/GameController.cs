using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public int gameScore;

    public GameObject player;
    public GameObject enemy;
    public GameObject mainCamera;
    public Text gameScoreUI;
    public Text gameOverUI;

    public Vector3 playerSpawnPos;

    private enum State
    {
        INGAME,
        GAMEOVER
    }

    private State gameState;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(Instance);
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        gameState = State.INGAME;
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameScoreUI.text = gameScore.ToString();

        switch (gameState)
        {
            case State.INGAME:

                if (!player.activeSelf)
                {
                    EndGame();
                }

                if (Input.GetKeyDown("n"))
                {
                    ResetGame();
                }

                break;

            case State.GAMEOVER:

                if (Input.GetKeyDown("n"))
                {
                    ResetGame();
                }

                break;
        }	
	}

    public void EndGame()
    {
        gameState = State.GAMEOVER;

        foreach(GameObject item in GameObject.FindGameObjectsWithTag("Item"))
        {
            Destroy(item);
        }

        gameOverUI.gameObject.SetActive(true);
        player.SetActive(false);
        enemy.SetActive(false);
    }

    public void ResetGame()
    {
        gameState = State.INGAME;

        gameScore = 0;

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Item"))
        {
            Destroy(item);
        }

        gameOverUI.gameObject.SetActive(false);
        player.SetActive(true);
        enemy.SetActive(true);

        player.transform.position = playerSpawnPos;

        /*
        EnemySpawner.Instance.ClearCurrentEnemies();
        EnemySpawner.Instance.spawning = true;
        UIController.Instance.HideGameOverTxt();
        */
    }

    public void IncreaseGameScore(int value)
    {
        gameScore += value;
    }
}
