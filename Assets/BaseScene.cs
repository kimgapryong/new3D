using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    public Defind.Scenes scenes { get; set; } = Defind.Scenes.Unknow;
    protected virtual void Init()
    {

    }
    public abstract void Clear();
}
