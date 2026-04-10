using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class CT_CheckAlertRadius : ConditionTask<Transform>
{
    public BBParameter<GameObject> player;
    public BBParameter<float> radiusLimit; 

    protected override bool OnCheck()
    {
        if (player.value == null) return false;

        float distance = Vector3.Distance(agent.position, player.value.transform.position);//check if the player is within the alert radius
        return distance <= radiusLimit.value;
    }
}