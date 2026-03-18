using UnityEngine;
using NodeCanvas.Framework; 

public class PigStatManager : MonoBehaviour
{
    private Blackboard blackboard;

    public float hungerDrainRate = 2f;
    public float moodDrainRate = 0.1f;

    void Start()
    {
        blackboard = GetComponent<Blackboard>();

    }

    void Update()
    {
        if (blackboard != null)
        {
            float currentHunger = blackboard.GetVariableValue<float>("Hunger");
            float currentMood = blackboard.GetVariableValue<float>("Mood");

            currentHunger -= hungerDrainRate * Time.deltaTime;
            currentMood -= moodDrainRate * Time.deltaTime;

            currentHunger = Mathf.Max(currentHunger, 0f);
            currentMood = Mathf.Max(currentMood, 0f);

            blackboard.SetVariableValue("Hunger", currentHunger);
            blackboard.SetVariableValue("Mood", currentMood);
        }
    }
}