using UnityEngine;

public class UI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup WinCanvasGroup;
    public WinScreenUIEffects WinScreenEffects;
    
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
        Debug.Log("ShowWinScreen");
        CanvasGroupDisplayer.Show(WinCanvasGroup);
        
        CanvasGroupDisplayer.Hide(GameOverCanvasGroup);
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);

        if (WinScreenEffects == null)
        {
            Debug.Log("WinScreenEffects is NOT assigned");
            return;
        }

        Debug.Log("Calling WinScreenEffects.PlayEffects()");
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
