using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    public Text lives;
    private int livesValue = 3;
    public Text loseText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource music;



    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        loseText.text= "";
        lives.text = livesValue.ToString();
        music.clip = musicClipOne;
        music.Play();
        music.loop = true;

    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
     
      private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
              Destroy(collision.collider.gameObject);
              if (scoreValue == 4)
              {
            transform.position = new Vector2(92.6f, .3f);
              }
              if (scoreValue == 8)
              {
                 music.Stop();
                 music.clip = musicClipTwo;
                 music.Play();
                  Destroy(rd2d);
                  
                  winText.text = "You Win! Game created by Dylan Brandon";
              }
        
        }
        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
             lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
            if (livesValue <= 0)
            {
                Destroy(rd2d);
                loseText.text = "You lose! Try again next time.";
            }
        }



    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
            }
        
        
        }
         

    }

    void Update()
    {
             if (Input.GetKey ("escape")) 
             {
                 Application.Quit();
                }
         }
}

    