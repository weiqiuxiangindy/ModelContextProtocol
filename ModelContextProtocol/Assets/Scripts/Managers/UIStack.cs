using UnityEngine;

public class UIStack : MonoBehaviour
{
#nullable disable
    [SerializeField] Transform _blocker;
#nullable enable
    int _elementCount;
    
    public T Push<T>(T prefab) where T : UIStackElement
    {
        PlusElementCount();
        
        var controller = Instantiate(prefab, transform);
        controller.UIStack = this;
        controller.Init();
        return controller;
    }

    public void Pop()
    {
        MinusElementCount();
    }

    void PlusElementCount()
    {
        _elementCount++;
        _blocker.SetSiblingIndex(_elementCount - 1);
    }
    
    void MinusElementCount()
    {
        _elementCount--;
        _blocker.SetSiblingIndex(_elementCount - 1);
    }
}
