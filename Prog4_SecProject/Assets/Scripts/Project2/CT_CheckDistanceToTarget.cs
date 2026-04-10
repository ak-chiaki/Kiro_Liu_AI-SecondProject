using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class CT_CheckDistanceToTarget : ConditionTask<Transform> 
{
    public BBParameter<GameObject> target;

    public float distanceThreshold = 3f;

    protected override bool OnCheck()
    {
        if (target.value == null)
        {
            return false; 
        }

        float currentDistance = Vector3.Distance(agent.position, target.value.transform.position);

        return currentDistance < distanceThreshold;
    }
}