using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private GameManager gameManager;

    public Transform bg1;
    public Transform bg2;
    private float size;
    private float startingX;

    private void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
        startingX = bg1.position.x;
    }

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {

            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
        else if(target.position.y < transform.position.y - 10) 
        {
            //dying
            MenuManager.instance.GameOver("Direction");
        }

        if (transform.position.y >= bg2.position.y)
        {
            //if the camera position is higher than the background, switch
            bg1.position = new Vector3(startingX, bg2.position.y + (size/2), bg1.position.z);
            SwitchBg();
        }

    }

    private void SwitchBg()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
