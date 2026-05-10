using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    
    public void OnPlayButtonClicked()
    {
        Ui.HideStartScreen();
    }
}
