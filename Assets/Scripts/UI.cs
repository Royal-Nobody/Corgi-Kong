using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup WinCanvasGroup;
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverCanvasGroup);
    }

    public void ShowWinScreen()
    {
        CanvasGroupDisplayer.Show(WinCanvasGroup);
    }
    
    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
    }
    
}
