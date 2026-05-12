using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public UI Ui;

    public bool isGameActive = false;
    
    public void OnPlayButtonClicked()
    {
        isGameActive = true;
        Ui.HideStartScreen();
    }

    public void TriggerGameOver()
    {
        isGameActive = false;
        Ui.ShowGameOverScreen();
    }

    public void PlayAgainButtonClicked()
    {
        //Actually reset stuff, but for now we will just reload the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //This effectively "resets" the game, by just reloading the scene from the beginning.
    }
}
