using Sirenix.OdinValidator.Editor.Validators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onWireOBJ : MonoBehaviour
{
    LineRenderer wire;
    public Color wireColor;
    wireController wireController;

    void Start()
    {
        wire = GetComponent<LineRenderer>();
        wire.startColor = wireColor;
        wire.endColor = wireColor;

        wireController = GameObject.Find("GameController").GetComponent<wireController>();
    }

    private void Update()
    {
        wire.SetPosition(0, transform.position);

        if (Input.GetMouseButtonDown(0) && wireController.isCreatingAWire)
        {
            wire.SetPosition(wire.positionCount + 1, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f));
        }
    }
}
