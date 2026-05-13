using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIEffects : MonoBehaviour
{
    public Canvas MainCanvas;
    public Image TitleImage;

    public Button StartButton;

    private Vector2 titleImageFinalPosition;
    private Vector2 startButtonFinalPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveEverythingOffScreen();
        StartCoroutine(PlayFlyinAnimations());
    }

    private IEnumerator PlayFlyinAnimations()
    {
        AnimateTitleImage();
        yield return new WaitForSeconds(1f);
        
        AnimateStartButton();
    }

    private void AnimateStartButton()
    {
        StartButton.GetComponent<RectTransform>().DOAnchorPos(startButtonFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }

    private void AnimateTitleImage()
    {
        TitleImage.rectTransform.DOAnchorPos(titleImageFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }

    private void MoveEverythingOffScreen()
    {
        titleImageFinalPosition = TitleImage.rectTransform.anchoredPosition;
        startButtonFinalPosition = StartButton.GetComponent<RectTransform>().anchoredPosition;

        float offScreenRight = MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenLeft = -MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenTop = MainCanvas.GetComponent<RectTransform>().rect.height;
        float offScreenBottom = -MainCanvas.GetComponent<RectTransform>().rect.height;
        
        TitleImage.rectTransform.anchoredPosition = new Vector2(offScreenRight, titleImageFinalPosition.y);
        StartButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(startButtonFinalPosition.x, offScreenTop + 150f);
    }
    
}
