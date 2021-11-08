using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    [SerializeField] private GameObject center;
    [SerializeField] private float setTimer;

    private Rigidbody2D rBody;
    private const float radius = 5f;
    private float angle;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > setTimer)
        {
            timer = 0;
            TransformPosition(angle);
            angle += 45;
        }
    }

    void TransformPosition(float angle)
    {
        transform.position = new Vector2(radius * Mathf.Cos(angle) + center.transform.position.x, radius * Mathf.Sin(angle) + center.transform.position.y);
    }
}
