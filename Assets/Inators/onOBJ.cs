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

    bool creatingWire = false;

    private void Start()
    {
        wireController = GameObject.Find("MainController").GetComponent<wireController>();
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (creatingWire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentWire.GetComponent<LineRenderer>().SetPosition(currentWire.GetComponent<LineRenderer>().positionCount + 1, new Vector3(mousePos.x, mousePos.y, 0));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentWire = Instantiate(wireController.wire, transform.position, Quaternion.identity);
                creatingWire = true;
            }
        }
    }
}
