using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField] private Text wellDone;

    // Start is called before the first frame update
    void Start()
    {
        wellDone.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            wellDone.enabled = true;
        }
    }
}
