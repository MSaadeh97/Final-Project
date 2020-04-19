using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    public static int scoreValue = 0;
    public Text winText;
    public int lives;
    public Text livesText;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    public bool isTouchingGround;
    private SpriteRenderer sprite;
    public AudioSource musicSource;
    public AudioSource musicSource2;
    public AudioClip musicClipThree;
    public AudioClip musicClipFour;
   

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        lives = 3;
        winText.text = "";
        SetScoreText();
        SetLivesText();
        sprite = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

        SetLivesText();

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        
        if (hozMovement > 0f)
        {            
            sprite.flipX = false;
        }
        else if (hozMovement < 0f)
        {            
            sprite.flipX = true;
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            SetScoreText();
            musicSource.clip = musicClipFour;
            musicSource.Play();
        }
       

        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            lives--;
            SetLivesText();
        }
        if (collision.collider.tag == "Pickmeups")
        {
            Destroy(collision.collider.gameObject);
            speed = 12;
           
            
            SetLivesText();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                musicSource.clip = musicClipThree;
                musicSource.Play();
            }
        }
    }

    void SetScoreText()
    {
        score.text = "Score: " + scoreValue.ToString();

        //Check if we've collected all 4 pickups. 
        if (scoreValue >= 8)
        {
             winText.text = "You win! Created by Mohammad Saadeh";
            Time.timeScale = 0;
           
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector2(36f, 0.1f);
            lives = 3;
        }
        

    }
    void SetLivesText()
    {
        livesText.text = "lives:" + lives.ToString();

        if (lives <= 0)
        {
            winText.text = "Game Over! Game created by Mohammad Saadeh!";
            Destroy(this);
        }

       

    }

    
}
