using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class onOBJ : MonoBehaviour
{
    BoxCollider2D collider;

    private void Start()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }
    }
}
