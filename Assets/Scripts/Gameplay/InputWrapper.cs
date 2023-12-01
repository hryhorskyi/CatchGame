using UnityEngine;

public class InputWrapper
{
    public float HorizontalMovement => Input.GetAxis("Horizontal");
    public bool IsJumpPressed => Input.GetButton("Jump");
}