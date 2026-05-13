using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup WinCanvasGroup;
    
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
        
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
        CanvasGroupDisplayer.Hide(WinCanvasGroup);
    }

    public void ShowGameOverScreen()
    {
        CanvasGroupDisplayer.Show(GameOverCanvasGroup);
        
        CanvasGroupDisplayer.Hide(WinCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }

    public void ShowWinScreen()
    {
        CanvasGroupDisplayer.Show(WinCanvasGroup);
        
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
    public void HideGameOverScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
    }

    public void HideWinScreen()
    {
        CanvasGroupDisplayer.Hide(WinCanvasGroup);
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
}
