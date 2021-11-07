using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private Rigidbody2D rBody;

    [SerializeField] private float bounce;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bounce" && rBody.velocity.y < 0)
            rBody.AddForce(transform.up * bounce, ForceMode2D.Impulse);
        
    }

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
}
