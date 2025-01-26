using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
   //오브젝트 넣을 거, 오브젝트 꺼낼 거, 자식 오브젝트 설정, 
    class Pool
    {
        public GameObject Original { get; private set; }
        public Transform Trans { get; set; }

        public Stack<PoolObj> poolObjs = new Stack<PoolObj>();
        public void Init(GameObject original, int count = 5)
        {
            Original = original;

            GameObject obj = new GameObject();
            obj.name = $"{Original.name}_Root";
            obj.transform.parent = Trans;
            
            Trans = obj.transform; 

            for(int i = 0; i < count; i++)
            {
                Push(Create());
            }
        }

        public PoolObj Create()
        {
            
            GameObject clone = Object.Instantiate(Original);
            clone.name = Original.name;


            return Util.AddScript<PoolObj>(clone);
        }

        public void Push(PoolObj obj)
        {
            if(obj == null) return;

            obj.transform.parent = Trans;
            obj.gameObject.SetActive(false);

            poolObjs.Push(obj);
        }

        public PoolObj Pop(Transform trans = null)
        {
            PoolObj poolObj;

            if (poolObjs.Count > 0)
                poolObj = poolObjs.Pop();
            else
                poolObj = Create();
           
            poolObj.transform.parent = trans;

            return poolObj;
        }
    }
    
    Dictionary<string, Pool> pools = new Dictionary<string, Pool>();
  
    public Transform root;
    public void Init()
    {
        GameObject obj = GameObject.Find("@PoolManager");
        if(obj == null)
        {
            obj = new GameObject();
            obj.name = "@PoolManager";
            root = obj.transform;
            Object.DontDestroyOnLoad(obj);
        }
    }

    public void Push(PoolObj pooling)
    {
        string name = pooling.gameObject.name;

        if (pools.ContainsKey(name) == false)
            Object.Destroy(pooling.gameObject);

        pools[name].Push(pooling);
    }

    public PoolObj Pop(GameObject obj)
    {
        if (pools.ContainsKey(obj.name) == false)
            CreatePool(obj);

        return pools[obj.name].Pop();
    }

    private void CreatePool(GameObject obj, int count = 5)
    {
        if (obj == null) return;

        Pool pool = new Pool();
        pool.Trans = root;
        pool.Init(obj, count);
        
        pools.Add(obj.name, pool);
    }

    public GameObject GetOriginal(string name)
    {
        if(pools.ContainsKey(name) == false) return null;

        return pools[name].Original;
    }
}
