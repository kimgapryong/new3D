using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    protected virtual void Init()
    {
        Manager.uiManager.SetOrder(gameObject, false);
    }
}
