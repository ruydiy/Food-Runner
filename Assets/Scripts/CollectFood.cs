using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public static int foodCount; // Counter to track the number of collected food items

    public void OnTriggerEnter(Collider collider)
    {
        GameObject collisionInitiator = collider.gameObject;

        if (collisionInitiator.tag == "Player")
        {
            base.gameObject.SetActive(false);
            foodCount++; // Increase the food counter by 1
            //Debug.Log("Food Count: " + foodCount); // Log the current food count to the console
        }
    }
}