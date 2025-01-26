using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX
{
    public BaseScene Scene { get { return GameObject.FindObjectOfType<BaseScene>(); }}

    public void LoadScene(Defind.Scenes type)
    {
        Scene.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Defind.Scenes type)
    {
        return Enum.GetName(typeof(Defind.Scenes), type);
    }
}
