using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    
    public void SetScoreText(string value, Color color)
    {
        if (scoreText)
        {
            scoreText.text = value;
            scoreText.color = color;
        }
    }

    public void ShowGameoverPanel(bool isShow)
    {
        gameoverPanel.SetActive(isShow);
    }
}
