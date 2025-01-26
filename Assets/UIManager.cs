using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    int order = 10;
    Stack<UI_Pop> pop_Stack = new Stack<UI_Pop>();

    GameObject Root
    {
        get
        {
            GameObject obj = GameObject.Find("@Root");
            if (obj != null)
                obj = new GameObject("@Root");
            return obj;
        }
    }
    public void SetOrder(GameObject obj, bool sort = true)
    {
        Canvas canvas = Util.AddScript<Canvas>(obj);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = order;
            order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    
    public T ShowPop_UI<T>(string name = null) where T : UI_Pop
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject clone = Manager.resources.Instantiate($"PopUp/{name}");
        //T component = clone.GetComponent<T>(); 내가 생각한 방식
        T component = Util.AddScript<T>(clone);
        pop_Stack.Push(component);

        clone.transform.SetParent(Root.transform);
        return component;
    }

    public T ShowScene_UI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject clone = Manager.resources.Instantiate($"Scene/{name}");
        T component = Util.AddScript<T>(clone);

        clone.transform.SetParent(Root.transform);
        return component;
    }

    public void DeletePop_UI()
    {
        if (pop_Stack.Count > 0)
            return;

        UI_Pop pop = pop_Stack.Pop();
        Manager.resources.Destroy(pop.gameObject);
        pop = null;
        order--;
    }
}
