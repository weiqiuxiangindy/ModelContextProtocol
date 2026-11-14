using UnityEngine;

public static class AppInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AppStart()
    {
        var managersPrefab = Resources.Load<AppManagers>("Managers");
        var globalCanvasPrefab = Resources.Load<GlobalCanvas>("GlobalCanvas");
        
        var managers = Object.Instantiate(managersPrefab);
        var globalCanvas = Object.Instantiate(globalCanvasPrefab);
        
        Object.DontDestroyOnLoad(managers);
        Object.DontDestroyOnLoad(globalCanvas);
        
        managers.Init();
    }
}
