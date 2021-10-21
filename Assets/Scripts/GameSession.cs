using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range(0.1f,10f)][SerializeField] private float gameSpeed = 1f;

    [SerializeField] private int pointsPerBlock = 42;

    [SerializeField] private int score = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool autoPlay;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        score += pointsPerBlock;
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        Destroy(gameObject);
    }

}
