using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    private static Managers sInstance;

    public static Managers Instance
    {
        get
        {
            Initialize();
            return sInstance;
        }
    }

    private UIManager uiManager;

    public static UIManager UIManager
    {
        get { return Instance.uiManager; }
    }

    private void Awake()
    {
        Initialize();

        uiManager = CreateManager<UIManager>("UIManager");
    }

    private void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene());

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private static void Initialize()
    {
        if (sInstance == null)
        {
            GameObject managersObj = GameObject.Find("@Managers");
            if (managersObj == null)
            {
                managersObj = new GameObject { name = "@Managers" };
            }

            Managers managers = managersObj.GetComponent<Managers>();
            if (managers == null)
            {
                managers = managers.AddComponent<Managers>();
            }

            sInstance = managers;
            DontDestroyOnLoad(managersObj);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnSceneLoaded(scene);
    }

    private void OnSceneLoaded(Scene scene)
    {

    }

    private void OnSceneUnloaded(Scene scene)
    {
        
    }

    private T CreateManager<T>(string managerName) where T : Component
    {
        T manager;
        GameObject managerObj = gameObject.transform.Find("@" + managerName)?.gameObject;

        if (managerObj == null)
        {
            managerObj = new GameObject { name = "@" + managerName };
            managerObj.transform.SetParent(gameObject.transform);
        }

        manager = managerObj.GetComponent<T>();

        if (manager == null)
        {
            manager = managerObj.AddComponent<T>();
        }

        DontDestroyOnLoad(managerObj);

        return manager;
    }
}
