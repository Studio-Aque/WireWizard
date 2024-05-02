using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class onOBJ : MonoBehaviour
{
    wireController wireController;

    GameObject currentWire;

    BoxCollider2D collider;

    private void Start()
    {
        wireController = GameObject.Find("MainController").GetComponent<wireController>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cursor")
        {
            if (Input.(0))
            {
                Instantiate(wireController.wire, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

                wireController.isCreatingAWire = true;
            }
        }
    }
}
