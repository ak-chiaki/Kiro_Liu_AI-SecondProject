using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class AT_YellowAlertAction : ActionTask<NavMeshAgent>
{
    public BBParameter<GameObject> player;

    protected override void OnExecute()
    {
        agent.GetComponent<Renderer>().material.color = Color.yellow;
    }

    protected override void OnUpdate()
    {
        if (player.value != null)
        {
            agent.SetDestination(player.value.transform.position);//chase the player
        }
        EndAction(true); 
    }
}