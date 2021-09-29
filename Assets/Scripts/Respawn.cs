using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Respawn : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Score.scoreValue -= 10;
            if (Score.scoreValue < 0)
                Score.scoreValue = 0;
        }
    }
}
