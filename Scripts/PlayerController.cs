using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float JumpForce;
    public bool isGrounded;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public Transform camera;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WinScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }       
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true)
            {
                rb.AddForce(transform.up * JumpForce);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
             if (isGrounded == true)
            {
                rb.AddForce(transform.up * JumpForce);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("Finish"))
        {
            Win();
        }
        if (other.CompareTag("Lava"))
        {
            Lose();
        }

    }
    void OnTriggerExit2D()
    {
        isGrounded = false;
    }

    public void Win()
    {
        WinScreen.SetActive(true);
    }
    public void Lose()
    {
        LoseScreen.SetActive(true);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        WinScreen.SetActive(false);
        LoseScreen.SetActive(false);
    }
}
