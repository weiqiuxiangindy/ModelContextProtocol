using UnityEngine;

public class UIStack : MonoBehaviour
{
#nullable disable
    [SerializeField] Transform _blocker;
#nullable enable
    
    public void Push(UIStackElement elementPrefab)
    {
        var controller = Instantiate(elementPrefab, transform);
        _blocker.SetSiblingIndex(controller.transform.GetSiblingIndex());
        controller.Init();
    }
}
