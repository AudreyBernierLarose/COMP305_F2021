using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Private variables
    private Vector3 startPos;

    //"Public" variables
    [SerializeField] private Transform player;
    [SerializeField] private float cameraStopY;

    [Range(1.0f, 10.0f)][SerializeField] private float cameraOffsetX = 5.0f;
    [Range(1.0f, 10.0f)][SerializeField] private float cameraOffsetY = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //Check the x threshold
        if (player.position.x < transform.position.x - (0.5f * cameraOffsetX))//Left
            transform.position = new Vector3(
                player.position.x + (0.5f * cameraOffsetX),
                transform.position.y,
                transform.position.z);

        else if (player.position.x > transform.position.x + (0.5f * cameraOffsetX))
            transform.position = new Vector3(
                player.position.x - (0.5f * cameraOffsetX),
                transform.position.y,
                transform.position.z);
        

        //Check the y threshold
        if (player.position.y < transform.position.y - (0.5f * cameraOffsetY))//Left
            transform.position = new Vector3(
                transform.position.x ,
                player.position.y + (0.5f * cameraOffsetY),
                transform.position.z);
        
        else if (player.position.y > transform.position.y + (0.5f * cameraOffsetY))
            transform.position = new Vector3(
               transform.position.x,
               player.position.y - (0.5f * cameraOffsetY),
               transform.position.z);
        

        //Checks if player is falling to its death
        if (player.position.y < -15)
            CameraStop();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(cameraOffsetX, cameraOffsetY, 0.0f));
    }

    private void CameraStop()
    {
        transform.position = new Vector3(
            transform.position.x,
            cameraStopY,
            transform.position.z);
        gameObject.transform.position = startPos;
    }
}
