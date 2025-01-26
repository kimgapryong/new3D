using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public static InputManager instance {  get; private set; }
    bool checkPress;

    public Action<InputMode> inputAction;
    public enum CameraMode
    {
        QuterView,
    }
    public enum InputMode
    {
        Press,
        Click,
    }

    public void OnUpdate()
    {
        if (Input.GetMouseButton(0)){
            if (inputAction != null) // null 확인
                inputAction.Invoke(InputMode.Press);
            checkPress = true;
        }
        else
        {
            if(checkPress)
                if (inputAction != null) // null 확인
                    inputAction.Invoke(InputMode.Click);
            checkPress = false;
        }
    }
}
