using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{

    private ProgressBar pb;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        if (gameObject.tag == "Ambition") {
            pb = GameObject.Find("Ambition Bar").GetComponent<ProgressBar>();
        }
        if (gameObject.tag == "Peace")
        {
            pb = GameObject.Find("Peace Bar").GetComponent<ProgressBar>();
        }       
        if (gameObject.tag == "Love")
        {
            pb = GameObject.Find("Love Bar").GetComponent<ProgressBar>();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by " + other.gameObject.name);
        if (other.gameObject == GameObject.Find("Player"))
        {
            pb.OnObjectPickedUp();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (player.GetComponent<Rigidbody2D>().position.y - 5 > this.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }

}
