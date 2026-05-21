using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIEffects : MonoBehaviour
{
    public Canvas MainCanvas;
    
    public Image GImage;
    public Image AImage;
    public Image MImage;
    public Image EImage;
    public Image OImage;
    public Image VImage;
    public Image E2Image;
    public Image RImage;
    public Button GameOverPlayButton;
    
    private Vector2 GImageFinalPosition;
    private Vector2 AImageFinalPosition;
    private Vector2 MImageFinalPosition;
    private Vector2 EImageFinalPosition;
    private Vector2 OImageFinalPosition;
    private Vector2 VImageFinalPosition;
    private Vector2 E2ImageFinalPosition;
    private Vector2 RImageFinalPosition;
    private Vector2 GameOverPlayButtonFinalPosition;

    void Start()
    {
        GImageFinalPosition = GImage.rectTransform.anchoredPosition;
        AImageFinalPosition = AImage.rectTransform.anchoredPosition;
        MImageFinalPosition = MImage.rectTransform.anchoredPosition;
        EImageFinalPosition = EImage.rectTransform.anchoredPosition;
        OImageFinalPosition = OImage.rectTransform.anchoredPosition;
        VImageFinalPosition = VImage.rectTransform.anchoredPosition;
        E2ImageFinalPosition = E2Image.rectTransform.anchoredPosition;
        RImageFinalPosition = RImage.rectTransform.anchoredPosition;
        GameOverPlayButtonFinalPosition = GameOverPlayButton.GetComponent<RectTransform>().anchoredPosition;
    }
    public void PlayGameOverEffects()
    {
        Debug.Log("Game Over effects are playing");

        MoveEverythingOffScreen_GameOver();
        StartCoroutine(PlayFlyingAnimations_GameOver());
    }

    private IEnumerator PlayFlyingAnimations_GameOver()
    {
        AnimateGImage();
        yield return new WaitForSeconds(0.5f);
        AnimateAImage();
        yield return new WaitForSeconds(0.5f);
        AnimateMImage();
        yield return new WaitForSeconds(0.5f);
        AnimateEImage();
        yield return new WaitForSeconds(0.5f);
        AnimateOImage();
        yield return new WaitForSeconds(0.5f);
        AnimateVImage();
        yield return new WaitForSeconds(0.5f);
        AnimateE2Image();
        yield return new WaitForSeconds(0.5f);
        AnimateRImage();
        yield return new WaitForSeconds(0.5f);
        AnimateGameOverPlayButton();
    }
    
    private void AnimateGameOverPlayButton()
    {
        GameOverPlayButton.GetComponent<RectTransform>().DOAnchorPos(GameOverPlayButtonFinalPosition, 0.8f)
            .SetEase(Ease.OutBounce);
    }
    
    private void AnimateGImage()
    {
        GImage.rectTransform.DOAnchorPos(GImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    
    private void AnimateAImage()
    {
        AImage.rectTransform.DOAnchorPos(AImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void AnimateMImage()
    {
        MImage.rectTransform.DOAnchorPos(MImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
        
    }
    private void AnimateEImage()
    {
        EImage.rectTransform.DOAnchorPos(EImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void AnimateOImage()
    {
        OImage.rectTransform.DOAnchorPos(OImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void AnimateVImage()
    {
        VImage.rectTransform.DOAnchorPos(VImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void AnimateE2Image()
    {
        E2Image.rectTransform.DOAnchorPos(E2ImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void AnimateRImage()
    {
        RImage.rectTransform.DOAnchorPos(RImageFinalPosition, 0.5f)
            .SetEase(Ease.OutBounce);
    }
    private void MoveEverythingOffScreen_GameOver()
    {
        float offScreenRight = MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenLeft = -MainCanvas.GetComponent<RectTransform>().rect.width;
        float offScreenTop = MainCanvas.GetComponent<RectTransform>().rect.height;
        float offScreenBottom = -MainCanvas.GetComponent<RectTransform>().rect.height;
        
        GImage.rectTransform.anchoredPosition = new Vector2(GImageFinalPosition.x, offScreenTop);
        AImage.rectTransform.anchoredPosition = new Vector2(AImageFinalPosition.x, offScreenTop);
        MImage.rectTransform.anchoredPosition = new Vector2(MImageFinalPosition.x, offScreenTop);
        EImage.rectTransform.anchoredPosition = new Vector2(EImageFinalPosition.x, offScreenTop);
        OImage.rectTransform.anchoredPosition = new Vector2(OImageFinalPosition.x, offScreenTop);
        VImage.rectTransform.anchoredPosition = new Vector2(VImageFinalPosition.x, offScreenTop);
        E2Image.rectTransform.anchoredPosition = new Vector2(E2ImageFinalPosition.x, offScreenTop);
        RImage.rectTransform.anchoredPosition = new Vector2(RImageFinalPosition.x, offScreenTop);
        GameOverPlayButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(GameOverPlayButtonFinalPosition.x, offScreenBottom);

    }
    
}

