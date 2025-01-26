using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if(index > 0 )
                name.Substring(index + 1);

            GameObject obj = Manager.pool.GetOriginal(name);
            if( obj != null ) 
                return obj as T;    
        }
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform trans = null)
    {
        PoolObj poolObj;
        GameObject obj = Load<GameObject>($"Prefab/{path}");
        if (obj == null)
            return null; 
            
        poolObj = obj.GetComponent<PoolObj>();
        if(poolObj != null)
        {
            return Manager.pool.Pop(obj).gameObject;   
        }
        return Object.Instantiate(obj, trans);
    }
    public void Destroy(GameObject obj)
    {
        if (obj != null)
            return;
        
        PoolObj poolObj = obj.GetComponent<PoolObj>();
        if (poolObj != null)
        {
            Manager.pool.Push(poolObj);
            return;
        }
        Object.Destroy(obj);
    }
}
