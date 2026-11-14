using UnityEngine;

public class GlobalCanvas : MonoBehaviour
{
#nullable disable
    [SerializeField] UIStack _uiStack;    
#nullable enable
    
    static GlobalCanvas _instance = null!;
    
    public static GlobalCanvas Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindAnyObjectByType<GlobalCanvas>();
            return _instance;
        }
    }
    
    public UIStack UIStack => _uiStack;

    void Awake()
    {
        _instance = this;
    }
}
