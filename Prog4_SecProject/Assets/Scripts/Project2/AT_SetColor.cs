using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

public class AT_SetColor : ActionTask<Transform>
{
    public Color targetColor = Color.blue;

    protected override void OnExecute()
    {
        agent.GetComponent<Renderer>().material.color = targetColor;
        EndAction(true); 
    }
}