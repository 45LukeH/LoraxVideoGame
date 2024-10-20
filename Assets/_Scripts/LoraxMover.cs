using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoraxMover : MonoBehaviour
{
    public float speed;
    private int seedCount = 0;
    public TextAlignment seedCountText;
    private bool isKnockedDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //UpdateSeedCountDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKnockedDown)
        {
            //Debug.Log(Time.deltaTime);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 newPos = new Vector2(
                   gameObject.transform.position.x + speed * Time.deltaTime,
                   gameObject.transform.position.y
                   );
                gameObject.transform.position = newPos;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector2 newPos = new Vector2(
                   gameObject.transform.position.x - speed * Time.deltaTime,
                   gameObject.transform.position.y
                   );
                gameObject.transform.position = newPos;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ThneedSeed"))
        {
            seedCount++;
            Destroy(other.gameObject);
            Debug.Log("Seeds: " + seedCount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object we collided with is tagged as "Axe"
        if (collision.gameObject.CompareTag("Axe"))
        {
            // Knock the Lorax down and end the game
            KnockDownLorax();
        }
    }
    private void KnockDownLorax()
    {
        // Disable movement by setting isKnockedDown to true
        isKnockedDown = true;

        // Optional: Add a visual or sound effect for the knockdown here (e.g., animation or sound)
        Debug.Log("Lorax has been knocked down!");

        // End the game after a short delay (e.g., 2 seconds)
        Invoke("EndGame", 2f);
    }
    private void EndGame()
    {
        // For simplicity, you can reload the current scene to simulate game over
        // You can also load a separate Game Over scene if needed
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Alternatively, quit the game (useful if this is for a build)
        // Application.Quit();
        Debug.Log("Game Over");
    }
}
