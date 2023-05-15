using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        GameObject collisionInitiator = collider.gameObject;

        if (collisionInitiator.tag == "Player")
        {
            base.gameObject.SetActive(false);
        }
    }
}