using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            Camera.main.GetComponent<AudioSource>().Stop();
            this.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            StartCoroutine(WaitMenu());
        }
    }

    IEnumerator WaitMenu()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
