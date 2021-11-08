using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    private Rigidbody2D rBody;

    [SerializeField] private float bounce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y < 0)
            rBody.AddForce(transform.up * bounce, ForceMode2D.Impulse);

        if (other.gameObject.tag == "End")
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            other.gameObject.GetComponent<AudioSource>().Play();
            rBody.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(WaitMenu());
        }
    }

    IEnumerator WaitMenu()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
}
