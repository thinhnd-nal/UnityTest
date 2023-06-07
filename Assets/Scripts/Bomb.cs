using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameController m_gameController;

    private void Start()
    {
        m_gameController = FindObjectOfType<GameController>();
    }
    
    private void Update()
    {
        if (m_gameController.IsGameover())
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            m_gameController.IncrementScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LoseZone"))
        {
            m_gameController.DecrementScore();
            Destroy(gameObject);
        }
    }
}
