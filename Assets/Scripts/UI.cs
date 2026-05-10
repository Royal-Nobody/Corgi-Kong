using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
}
