using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject Obstacle;

    public Transform Spawn;

    public float XReals;

    public static GameManager instance;

    int Score = 0;

    int HighScore = 0;

    public Text ScoreText;

    public Text HighScoreText;

    bool IsPlaying = false;

    public GameObject MenuPanel;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {

            HighScore = PlayerPrefs.GetInt("highScore");

            HighScoreText.text = "High Score: " + HighScore.ToString();

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && !IsPlaying)
        {

            MenuPanel.gameObject.SetActive(false);

            ScoreText.gameObject.SetActive(true);

            StartCoroutine("GenerateObstacles");

            IsPlaying = true;

        }

    }

    IEnumerator GenerateObstacles()
    {

        while (true)
        {

            yield return new WaitForSeconds(0.8f);

            SpawnObstacle();

        }

    }

    public void SpawnObstacle()
    {

        float X = Random.Range(-XReals, XReals);

        Vector3 Position = Spawn.position;

        Position.x = X;

        Instantiate(Obstacle, Position, Quaternion.identity);

    }

    public void Restart()
    {

        if (Score > HighScore)
        {

            HighScore = Score;

            PlayerPrefs.SetInt("highScore", HighScore);

        }

        SceneManager.LoadScene(0);

    }

    public void GameOver()
    {
        IsPlaying = false;
    }

    public void UpdateScore()
    {
        
        if (IsPlaying)
        {

            Score++;

            ScoreText.text = Score.ToString();

        }

    }

}
