using System.Collections;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject popup; // Reference to the popup Panel

    private void Start()
    {
        // Ensure the popup is hidden when the scene starts
        popup.SetActive(false);
    }

    // Call this method when the game is over
    public void ShowGameOverPopup()
    {
        StartCoroutine(ShowPopupAfterDelay(4f)); // Change 4f to the duration you want for the Once-ler's laughter
    }

    private IEnumerator ShowPopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified duration
        popup.SetActive(true); // Show the popup
    }

    public void ReplayGame()
    {
        // Load your game scene here
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu"); // Replace with your actual scene name
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
