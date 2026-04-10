using UnityEngine;
using NodeCanvas.Framework; 

public class PlayerInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); 

            GlobalBlackboard.Find("GlobalAlarmSystem").SetVariableValue("HasKey", true);

            Debug.Log("Get Key！");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            bool hasKey = GlobalBlackboard.Find("GlobalAlarmSystem").GetVariableValue<bool>("HasKey");//check if player has the key

            if (hasKey)
            {
                Destroy(collision.gameObject); 
                Debug.Log("Door Open! YOU WIN ! ");
            }
            else
            {
                Debug.Log("You need a Key to Open the door!"); // player cannot open the door without the key
            }
        }
    }
}