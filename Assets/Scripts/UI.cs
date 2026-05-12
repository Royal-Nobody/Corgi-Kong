using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverCanvasGroup);
    }
    
    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
    }
    
}
