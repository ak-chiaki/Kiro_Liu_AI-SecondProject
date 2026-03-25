using UnityEngine;
using UnityEngine.InputSystem; 

public class SimplePlayer : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (Keyboard.current == null) return;

        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveVertical += 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveVertical -= 1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveHorizontal -= 1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveHorizontal += 1f;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}