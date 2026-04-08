using UnityEngine;
using NodeCanvas.Framework; 

public class PlayerInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); 

            GlobalBlackboard.Find("GameManager").SetVariableValue("HasKey", true);
            Debug.Log("Get Key！");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            bool hasKey = GlobalBlackboard.Find("GameManager").GetVariableValue<bool>("HasKey");

            if (hasKey)
            {
                Destroy(collision.gameObject); 
                Debug.Log("Door Open");
            }
            else
            {
                Debug.Log("You need a Key to Open the door!");
            }
        }
    }
}