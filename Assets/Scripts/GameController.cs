using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    UIManager m_uiManager;
    public GameObject bomb;
    public float spawnTime;
    float m_spawnTime;

    int m_score;
    bool m_isGameover;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_uiManager.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnBomb();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnBomb()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-5f, 5f), 4);
        if (bomb)
        {
            Instantiate(bomb, spawnPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        m_score = 0;
        m_isGameover = false;
        m_uiManager.SetScoreText("Score: " + m_score, Color.green);
        m_uiManager.ShowGameoverPanel(false);
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }

    public bool IsGameover()
    {
        return m_isGameover;
    }

    public void IncrementScore() {
        m_score++;
        m_uiManager.SetScoreText("Score: " + m_score, Color.green);
    }

    public void DecrementScore()
    {
        m_score -= 5;
        m_uiManager.SetScoreText("Score: " + m_score, Color.red);
        if (m_score < 0)
        {
            SetGameOverState(true);
        }
    }

    public void SetGameOverState(bool state)
    {
        m_isGameover = state;
    }
}
