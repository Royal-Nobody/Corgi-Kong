using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenUIEffects : MonoBehaviour
{
    public Canvas MainCanvas;
    
    public Image WinTitleImage;
    public Image CorgiResquedImage;
    public Button WinPlayButton;
    
    private Vector2 WinTitleImageFinalPosition;
    private Vector2 CorgiResquedFinalPosition;
    private Vector2 WinPlayButtonFinalPosition;

    void Start()
    {
        WinTitleImageFinalPosition = WinTitleImage.rectTransform.anchoredPosition;
        CorgiResquedFinalPosition = CorgiResquedImage.rectTransform.anchoredPosition;
        WinPlayButtonFinalPosition = WinPlayButton.GetComponent<RectTransform>().anchoredPosition;
    }
    public void PlayEffects()
    {

        MoveEverythingOffScreen_WinScreen();
        StartCoroutine(PlayFlyinAnimations_WinScreen());
    }

    private IEnumerator PlayFlyinAnimations_WinScreen()
    {
        AnimateWinTitleImage();
        yield return new WaitForSeconds(1f);
        AnimateCorgiResquedImage();
        yield return new WaitForSeconds(1f);
        AnimateWinPlayButton();
    }
    
    private void AnimateWinPlayButton()
    {
        WinPlayButton.GetComponent<RectTransform>().DOAnchorPos(WinPlayButtonFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }
    
    private void AnimateCorgiResquedImage()
    {
        CorgiResquedImage.rectTransform.DOAnchorPos(CorgiResquedFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }
    
    private void AnimateWinTitleImage()
    {
        WinTitleImage.rectTransform.DOAnchorPos(WinTitleImageFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }

    private void MoveEverythingOffScreen_WinScreen()
    {
        float offScreenRight = MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenLeft = -MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenTop = MainCanvas.GetComponent<RectTransform>().rect.height;
        float offScreenBottom = -MainCanvas.GetComponent<RectTransform>().rect.height;
        
        WinTitleImage.rectTransform.anchoredPosition = new Vector2(offScreenTop + 500f, WinTitleImageFinalPosition.x);
        CorgiResquedImage.rectTransform.anchoredPosition = new Vector2(offScreenBottom - 500f, CorgiResquedFinalPosition.x);
        WinPlayButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(WinPlayButtonFinalPosition.y, offScreenLeft + 500f);

    }
    
}