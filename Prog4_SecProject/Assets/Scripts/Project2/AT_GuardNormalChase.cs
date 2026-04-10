using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

public class AT_GuardNormalChase : ActionTask<NavMeshAgent>
{
    public BBParameter<GameObject> player;
    public BBParameter<float> catchDistance;
    public BBParameter<float> loseSightDistance;//parameters for the guard to catch the player and lose sight of the player
    public BBParameter<float> normalSpeed = 3.5f; 
    private Transform startPoint;

    protected override void OnExecute()
    {
        agent.GetComponent<Renderer>().material.color = Color.red;
        agent.speed = normalSpeed.value; 

        GameObject sp = GameObject.Find("StartPoint");
        if (sp != null) startPoint = sp.transform;
    }

    protected override void OnUpdate()
    {
        if (player.value == null) return;
        float dist = Vector3.Distance(agent.transform.position, player.value.transform.position);

        if (dist <= catchDistance.value)//catch the player and return to start point
        {
            if (startPoint != null)
            {
                player.value.transform.position = startPoint.position;
                Rigidbody rb = player.value.GetComponent<Rigidbody>();
            }
            EndAction(true); 
            return;
        }

        if (dist > loseSightDistance.value)
        {
            EndAction(false); // failed to catch the player
            return;
        }

        agent.SetDestination(player.value.transform.position);//keep chasing the player
    }
}