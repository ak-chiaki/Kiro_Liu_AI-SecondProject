using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class CT_CheckGameObjectNull : ConditionTask
{
    public BBParameter<GameObject> target;

    protected override bool OnCheck()
    {
        return target.value == null; //Check if the GameObject is null in global blackboard
    }
}