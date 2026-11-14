using UnityEngine;

public class PrefabRegister : MonoBehaviour
{
    static PrefabRegister _instance = null!;
    public static PrefabRegister Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindAnyObjectByType<PrefabRegister>();
            return _instance;
        }
    }
    
#nullable disable
    public HomeViewController HomeView;
    public StoreViewController StoreView;
#nullable enable
}
