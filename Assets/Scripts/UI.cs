using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;
    public CanvasGroup WinScreenCanvasGroup;
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }
    
    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }

    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
    }
    
    public void HideWinScreen()
    {
        CanvasGroupDisplayer.Hide(WinScreenCanvasGroup);
    }

    public void ShowWinScreen()
    {
        CanvasGroupDisplayer.Show(WinScreenCanvasGroup);
    }
}
