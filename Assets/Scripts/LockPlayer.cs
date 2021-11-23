using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayer : MonoBehaviour
{
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitMove());
    }

    IEnumerator WaitMove()
    {
        rBody.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(9.2f);
        rBody.constraints = ~RigidbodyConstraints2D.FreezePosition;
    }

   
}
