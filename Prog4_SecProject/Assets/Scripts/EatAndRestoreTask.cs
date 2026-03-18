using NodeCanvas.Framework;
using ParadoxNotion.Design;

public class EatAndRestoreTask : ActionTask
{
    public BBParameter<float> hunger;
    public BBParameter<float> mood;

    public float maxHunger = 100f;
    public float maxMood = 10f;

    protected override void OnExecute()
    {
        hunger.value = maxHunger;
        mood.value = maxMood;

        EndAction(true);
    }
}