using System.Collections;
using UnityEngine;

public class MechanicalPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;     
    public float waitTime = 1f;       
    public float scanRange = 2f;      

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(PatrolRoutine());
    }

    IEnumerator PatrolRoutine()
    {
        Vector3[] points = new Vector3[]
        {
            startPos + new Vector3(scanRange, 0, 0),      
            startPos + new Vector3(scanRange, 0, scanRange), 
            startPos + new Vector3(0, 0, scanRange),      
            startPos                                      
        };

        int index = 0;

        while (true)
        {
            Vector3 target = points[index];

            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
                yield return null; 
            }

            yield return new WaitForSeconds(waitTime);

            index = (index + 1) % points.Length;
        }
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            startPos = transform.position;
        }

        Gizmos.color = Color.green;
        Vector3 p1 = startPos + new Vector3(scanRange, 0, 0);
        Vector3 p2 = startPos + new Vector3(scanRange, 0, scanRange);
        Vector3 p3 = startPos + new Vector3(0, 0, scanRange);

        Gizmos.DrawLine(startPos, p1);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, startPos);
    }
}