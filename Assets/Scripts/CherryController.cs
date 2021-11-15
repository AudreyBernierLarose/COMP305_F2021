using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject itemFeedback;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Play an "item pickup" animations
            GameObject.Instantiate(itemFeedback, this.transform.position, this.transform.rotation);

            //Increase player item pickup counter
            LevelController.Instance.PickedUpItem();
            Destroy(this.gameObject);
        }
    }

}
