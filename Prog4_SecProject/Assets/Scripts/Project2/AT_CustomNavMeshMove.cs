using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class AT_CustomNavMeshMove : ActionTask<NavMeshAgent>
{
    public BBParameter<GameObject> targetPoint;
    public BBParameter<float> stopDistance = 0.2f;

    protected override void OnExecute()
    {
        if (targetPoint.value == null)
        {
            EndAction(false); return;
        }
        agent.SetDestination(targetPoint.value.transform.position);
    }

    protected override void OnUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= stopDistance.value)
        {
            EndAction(true);
        }
    }
}