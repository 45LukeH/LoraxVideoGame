using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameOverManager gameOverManager; // Reference to GameOverManager
    [SerializeField] private PlayableDirector onceLerTimeline; // Reference to your Playable Director

    public void EndGame()
    {
        // Start the Once-ler's timeline
        onceLerTimeline.Play();

        // Use a coroutine to wait for the timeline to finish
        StartCoroutine(WaitForTimelineToEnd());
    }

    private IEnumerator WaitForTimelineToEnd()
    {
        // Wait for the duration of the timeline
        yield return new WaitForSeconds((float)onceLerTimeline.duration); // Ensure this is the correct duration

        // Now call the ShowGameOverPopup method
        gameOverManager.ShowGameOverPopup();
    }
}
