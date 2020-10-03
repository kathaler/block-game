using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 7f;

    float halfScreenHorizontal;
    float playerHalfWidth;

    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerHalfWidth = transform.localScale.x / 2;
        halfScreenHorizontal = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 velocity = input * speed;

        transform.Translate(velocity * Time.deltaTime);

        if(transform.position.x < -halfScreenHorizontal - playerHalfWidth)
        {
            transform.position = new Vector2(halfScreenHorizontal, transform.position.y);
        }
        if (transform.position.x > halfScreenHorizontal + playerHalfWidth)
        {
            transform.position = new Vector2(-halfScreenHorizontal, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
