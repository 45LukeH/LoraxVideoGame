using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncelerFollowLorax : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public int damage = 1;
    private PlayerHealth playerHealth;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Lorax");

        if(player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lorax"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            transform.position = startingPosition;
        }
    }
}
