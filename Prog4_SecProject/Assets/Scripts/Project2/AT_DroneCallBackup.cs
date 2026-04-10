using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class AT_DroneCallBackup : ActionTask<Transform>
{
    protected override void OnExecute()
    {
        var globalBB = GlobalBlackboard.Find("GlobalAlarmSystem");
        if (globalBB != null)
        {
            globalBB.SetVariableValue("isAwake", true); // Set the alarm system to awake and awake the robot.
            globalBB.SetVariableValue("targetDrone", agent.gameObject); // Set the target dro
        }
        EndAction(true);
    }
}