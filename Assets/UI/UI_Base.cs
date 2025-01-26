using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> objects = new Dictionary<Type, UnityEngine.Object[]>();  
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];
        objects.Add(typeof(T), objs);

        for(int i =0;  i < names.Length; i++)
        {
            if(typeof(T) == typeof(GameObject))
                objs[i] = Util.FindType(gameObject, names[i], true);
            else
                objs[i] = Util.FindType<T>(gameObject, names[i], true);
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objs = null;
        if (objects.TryGetValue(typeof(T), out objs) == false)
            return null;

        return objs[idx] as T;
    }

    protected Text GetText(int idx)
    {
        return Get<Text>(idx);
    }
    protected GameObject GetObj(int idx)
    {   
        return Get<GameObject>(idx);
    }
    protected void AddEvente(GameObject obj, Action<PointerEventData> action, UIEvent.UIMode UiMode = UIEvent.UIMode.Drag)
    {
        UIEvent Uievent = Util.AddScript<UIEvent>(obj);
        
        switch(UiMode)
        {
            case UIEvent.UIMode.Drag:
                Uievent.dragEvent -= action;
                Uievent.dragEvent += action;
                break;
            case UIEvent.UIMode.Click:
                Uievent.clickEvent -= action;
                Uievent.clickEvent += action;
                break;
        }
    }
}
