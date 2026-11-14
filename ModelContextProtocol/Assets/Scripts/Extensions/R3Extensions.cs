using R3;
using UnityEngine;
using UnityEngine.UI;

public static class R3Extensions
{
    public static Observable<Unit> OnClickAsSingleObservable(this Button button)
    {
        return button.OnClickAsObservable().Where(_ => true);   // TODO::whereの所にマルチクリックを防ぐ機能を実装
    }
}