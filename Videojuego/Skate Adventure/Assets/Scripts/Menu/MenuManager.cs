using UnityEngine;
using UnityEngine.SceneManagement; // This is the most important line for navigation

public class MenuManager : MonoBehaviour
{
    // This function will be called when the PLAY button is pressed
    public void StartGame()
    {
        // We set TimeScale to 1 to ensure the game isn't paused when it starts
        Time.timeScale = 1f;

        // Loads the gameplay scene. Make sure your game level is index 1 in Build Settings
        SceneManager.LoadScene(1);
    }

    // This function will be called from the Game Over or Pause screen to return to the beach
    public void GoToMainMenu()
    {
        // Unfreezes the game time before shifting back to ensure the main menu works correctly
        Time.timeScale = 1f;

        // Loads the main menu scene. Make sure it is index 0 in Build Settings
        SceneManager.LoadScene(0);
    }

    // This function will be called if you add a QUIT button
    public void QuitGame()
    {
        Debug.Log("The game is closing...");
        Application.Quit();
    }
}