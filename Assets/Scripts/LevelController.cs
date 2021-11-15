using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //Singleton
    private static LevelController _instance;
    public static LevelController Instance { get { return _instance; } }

    //Private variables
    private int totalItemsQty = 0, itemsCollectedQty = 0;

    //Public variables
    [SerializeField] private Text uiText;
    [SerializeField] private Text wellDone;
    [SerializeField] private GameObject end;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        wellDone.enabled = false;

        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
        //Debug.Log("There are : " + totalItemsQty + " items");
        UpdateItemUI();
    }

    public void PickedUpItem()
    {
        itemsCollectedQty++;
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        uiText.text = itemsCollectedQty + " / " + totalItemsQty;
    }

    public void CheckLevelEnd()
    {
        if (itemsCollectedQty == totalItemsQty)
        {
            //Go to the next level
            StartCoroutine(WaitSound());
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator WaitSound()
    {
        wellDone.enabled = true;
        end.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3.0f);
    }
}
