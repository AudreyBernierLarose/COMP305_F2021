using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Respawn : MonoBehaviour
{
    [SerializeField] private Text gameOver;

    void Start()
    {
        gameOver.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Score.scoreValue -= 10;
            if (Score.scoreValue < 1)
            {
                Score.scoreValue = 0;
                gameOver.enabled = true;

            }
        }
    }
}
