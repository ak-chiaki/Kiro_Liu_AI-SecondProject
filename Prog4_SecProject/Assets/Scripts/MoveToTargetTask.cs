using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTargetTask : ActionTask<NavMeshAgent>
{
    public BBParameter<GameObject> targetFood;

    protected override void OnExecute()
    {
        if (targetFood.value != null)
        {
            agent.SetDestination(targetFood.value.transform.position);
        }
        else
        {
            EndAction(false);
        }
    }

    protected override void OnUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            EndAction(true);
        }
    }
}