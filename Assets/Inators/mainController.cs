using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mainController : MonoBehaviour
{
    public GameObject prefab;

    public Camera camera;

    public float gridSpacing = 1f; // Distance between grid points

    LineRenderer lR;

    public List<Transform> spawnedObjects = new List<Transform>();

    void Start()
    {
        lR = GetComponent<LineRenderer>();
        SpawnObjectsOnGrid();
    }

    void SpawnObjectsOnGrid()
    {
        // Calculate the visible area of the camera in world space
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;

        // Calculate the center of the camera's view
        Vector3 center = camera.transform.position;

        // Calculate the half-width and half-height of the camera's view
        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        // Calculate the number of grid points in the horizontal and vertical directions
        int horizontalPoints = Mathf.RoundToInt(halfWidth / gridSpacing) + 1;
        int verticalPoints = Mathf.RoundToInt(halfHeight / gridSpacing) + 1;

        // Spawn objects along the grid and add them to the list
        for (int i = -horizontalPoints; i <= horizontalPoints; i++)
        {
            for (int j = -verticalPoints; j <= verticalPoints; j++)
            {
                // Calculate the position of the grid point
                float x = center.x + i * gridSpacing;
                float y = center.y + j * gridSpacing;
                Vector3 spawnPosition = new Vector3(x, y, center.z);

                // Instantiate the prefab at the calculated position
                GameObject spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);

                // Add the spawned object to the list
                spawnedObjects.Add(spawnedObject.transform);
            }
        }
    }

    private void Update()
    {
        Cursor();
    }

    void Cursor()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distanceBetween = Mathf.Infinity;
        Transform closestObject = null;

        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (Vector2.Distance(cursorPosition, new Vector2(spawnedObjects[i].position.x, spawnedObjects[i].position.y)) <= distanceBetween)
            {
                distanceBetween = Vector2.Distance(cursorPosition, new Vector2(spawnedObjects[i].position.x, spawnedObjects[i].position.y));
                closestObject = spawnedObjects[i];
            }
        }

        if (Input.GetMouseButtonDown(0))
        {

        }


        lR.SetPosition(0, cursorPosition);
        lR.SetPosition(1, closestObject.position);
        Debug.Log(closestObject.position);
        
    }
}
