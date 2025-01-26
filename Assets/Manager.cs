using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager instance;
    public static Manager GetInstance { get { Init(); return instance; } }

    ResourcesManager resource = new ResourcesManager();
    InputManager input = new InputManager();
    PoolManager _pool = new PoolManager();
    UIManager ui = new UIManager();

    public static ResourcesManager resources { get { return GetInstance.resource; } }
    public static PoolManager pool {  get { return GetInstance._pool; } }
    public static InputManager inputManager { get { return GetInstance.input; } }
    public static UIManager uiManager { get { return GetInstance.ui; } }

    GameObject obj;
    private void Awake()
    {
        Init();
    }
    void Start()
    {
      obj = resource.Instantiate("Button_Ui");
    }
    private void Update()
    {
        input.OnUpdate();
    }

    static void Init()
    {
        if(instance == null)
        {
            GameObject go = GameObject.Find("Manager");
            if (go == null)
            {
                go = new GameObject("Manager");
                go.AddComponent<Manager>();
            }
            instance = go.GetComponent<Manager>();
            DontDestroyOnLoad(go);

            pool.Init();

        }

    }
}
