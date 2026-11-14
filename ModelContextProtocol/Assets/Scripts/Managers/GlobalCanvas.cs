using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalCanvas : MonoBehaviour
{
#nullable disable
    [SerializeField] UIStack _uiStack;
    [SerializeField] Camera _uiCamera;
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

    public void StackUICamera()
    {
        var mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("MainCamera is null");
            return;
        }
        mainCamera.GetUniversalAdditionalCameraData().cameraStack.Add(_uiCamera);
    }
}
