using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class AT_RedAlertAction : ActionTask<NavMeshAgent>
{

    protected override void OnExecute()
    {
        agent.GetComponent<Renderer>().material.color = Color.red;
        if (agent.isOnNavMesh) agent.ResetPath(); // Stop
    }

    protected override void OnUpdate()
    {
        EndAction(true);
    }
}