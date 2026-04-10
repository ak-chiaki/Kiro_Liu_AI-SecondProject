using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class AT_ClearTargetDrone : ActionTask
{
    protected override void OnExecute()
    {
        var globalBB = GlobalBlackboard.Find("GlobalAlarmSystem");
        if (globalBB != null)
        {
            globalBB.SetVariableValue("targetDrone", null); // Clear the target drone in the global blackboard
        }
        EndAction(true);
    }
}