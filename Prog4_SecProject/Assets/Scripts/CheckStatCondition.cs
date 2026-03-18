using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class CheckStatCondition : ConditionTask
{
    public BBParameter<float> statToCheck;

    public float threshold;

    protected override bool OnCheck()
    {
        if (statToCheck.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}