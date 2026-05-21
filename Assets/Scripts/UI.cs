using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup WinCanvasGroup;
    public WinScreenUIEffects WinScreenEffects;
    public GameOverUIEffects GameOverEffects;
    
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
        
        GameOverEffects.PlayGameOverEffects();
    }

    public void ShowWinScreen()
    {
        CanvasGroupDisplayer.Show(WinCanvasGroup);
        
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);

        WinScreenEffects.PlayEffects();
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
