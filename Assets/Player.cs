using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;

    public Rigidbody2D rb;
    public string currentColor;
    public SpriteRenderer sr;


    public Color colorCyan;
    public Color colorYellow;
    public Color colorRed;
    public Color colorGreen;


    private void Start()
    {
        SetRandomColor(currentColor);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "colorChanger")
        {
            string prevColor = currentColor;
            SetRandomColor(currentColor);
            
            return;
            //Destroy(collision.gameObject);
            
        }

        if(collision.tag != currentColor)
        {
            //Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    void SetRandomColor(string presentColor)
    {
        int index = Random.Range(0, 4);
        int prev;
        if(presentColor == "cyan")
        {
            prev = 0;
        }
        else if (presentColor == "yellow")
        {
            prev = 1;
        }
        else if (presentColor == "green")
        {
            prev = 2;
        }
        else
        {
            prev = 3;
        }

        while(index==prev)
        {
            index = Random.Range(0, 4);
        }


        switch (index)
        {
            case 0:
                currentColor = "cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "green";
                sr.color = colorGreen;
                break;
            case 3:
                currentColor = "red";
                sr.color = colorRed;
                break;
        }
    }
}
