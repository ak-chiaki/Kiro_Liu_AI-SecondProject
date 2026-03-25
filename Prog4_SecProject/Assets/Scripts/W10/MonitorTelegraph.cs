using UnityEngine;

public class MonitorTelegraph : MonoBehaviour
{
    public Transform player;
    public float yellowAlertRadius = 6f;
    public float redAlertRadius = 3f;

    private Renderer monitorRenderer;

    void Start()
    {
        monitorRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= redAlertRadius)
        {
            monitorRenderer.material.color = Color.red;
        }
        else if (distance <= yellowAlertRadius)
        {
            monitorRenderer.material.color = Color.yellow;
        }
        else
        {
            monitorRenderer.material.color = Color.blue;
        }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, yellowAlertRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, redAlertRadius);
        }
    }
