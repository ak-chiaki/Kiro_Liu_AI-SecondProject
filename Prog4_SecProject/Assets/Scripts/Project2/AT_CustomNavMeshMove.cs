using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


public class CustomNavMeshMove : ActionTask<NavMeshAgent>
{
    public BBParameter<GameObject> targetPoint;
    public float stopDistance = 0.2f;


    protected override void OnExecute()
    {
        if (targetPoint.value == null)
        {
            EndAction(false); 
            return;
        }

        agent.SetDestination(targetPoint.value.transform.position);
    }

    protected override void OnUpdate()
    {
        if (agent.pathPending) return;

        if (agent.remainingDistance <= stopDistance)
        {
            EndAction(true); 
        }
    }

    protected override void OnStop()
    {
        if (agent.gameObject.activeSelf && agent.isOnNavMesh)
        {
            agent.ResetPath(); 
        }
    }
}