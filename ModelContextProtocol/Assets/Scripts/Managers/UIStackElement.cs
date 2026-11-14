using UnityEngine;

public abstract class UIStackElement : MonoBehaviour
{
    public UIStack UIStack { get; set; } = GlobalCanvas.Instance.UIStack;
    public abstract void Init();
}
