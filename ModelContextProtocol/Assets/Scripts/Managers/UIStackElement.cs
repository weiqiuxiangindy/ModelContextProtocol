using UnityEngine;

public abstract class UIStackElement : MonoBehaviour
{
    public UIStack UIStack { get; set; }
    public abstract void Init();
}
