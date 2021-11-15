using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionDestroyer : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
