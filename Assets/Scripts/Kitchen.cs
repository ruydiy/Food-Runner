using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    private MeshCollider meshCollider;

    private void Start()
    {
        // Get the MeshCollider component
        meshCollider = GetComponent<MeshCollider>();
    }
    private void Update()
    {
        // Access the foodCount counter from the CollectFood script
        int collectedFoodCount = CollectFood.foodCount;

        if (collectedFoodCount > 2)
        {
            DisableCollider();
        }
        // Use the collectedFoodCount value in your desired logic or display it in the UI
        Debug.Log("Collected Food Count: " + collectedFoodCount);
    }

    private void DisableCollider()
    {
        // Disable the MeshCollider
        meshCollider.enabled = false;
    }
}
