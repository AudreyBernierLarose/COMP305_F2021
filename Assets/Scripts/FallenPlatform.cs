using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenPlatform : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    [SerializeField] private float velocity;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isShaking", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isShaking", true);
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(WaitFallenPlatform());
        }
    }

    IEnumerator WaitFallenPlatform()
    {
        yield return new WaitForSeconds(1.5f);
        rBody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        rBody.velocity = new Vector2(transform.position.x, velocity);
    }
}
