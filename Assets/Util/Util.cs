using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //오브젝트를 반환해주는 유틸
    public static GameObject FindType(GameObject obj, string name = null, bool regist = false)
    {
        Transform trans = FindType<Transform>(obj, name, regist);

        if(trans != null)
            return trans.gameObject;

        return null;
    }
   public static T FindType<T>(GameObject obj, string name = null, bool regist = false) where T : Object
    {
        if (obj == null)
            return null;

        if (regist == false)
        {
            for(int i = 0; i < obj.transform.childCount; i++)
            {
                Transform child = obj.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || child.name == name)
                {
                    T component = child.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach(T com in obj.GetComponentsInChildren<T>())
            {
                if(string.IsNullOrEmpty(name) || name == com.name)
                    return com;
            }
        }

        return null;
    }

    public static T AddScript<T>(GameObject obj) where T : UnityEngine.Component
    {
        T componet = obj.GetComponent<T>();
        if(componet == null)
            componet = obj.AddComponent<T>();
        return componet;
    }
}
