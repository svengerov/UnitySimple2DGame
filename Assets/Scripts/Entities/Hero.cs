using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hero : Entity
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int lives = 5;
    [SerializeField] private int score = 0;
    [SerializeField] private float jumpForce = 3f;
    private int coinsCount = 0;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource hitEnemySoundEffect;
    [SerializeField] private AudioSource dyingSoundEffect;

    public Text scoreUI;

    public int getCoinsCount()
    {
        return coinsCount;
    }
    public int getLives()
    {
        return lives;
    }
    public int getScore()
    {
        return score;
    }
    private States State
    {
        get 
        {
            return (States)anim.GetInteger("state"); 
        }
        set 
        {
        anim.SetInteger("state", (int) value);
        }
    }
    public static Hero Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
        CheckIfFall();
    }

    private void Update()
    {
        if (isGrounded) State = States.Player_idle;
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Run()
    {
        if (isGrounded) State = States.Player_run;
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime); //current,next,speed
        sprite.flipX = direction.x < 0f;
    }
    private void Jump()
    {
        jumpSoundEffect.Play();
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[]collider = Physics2D.OverlapCircleAll(transform.position, 1.6f);
        isGrounded = collider.Length > 1;
        if (!isGrounded ) State = States.Player_jump;
    }

    private void CheckIfFall()
    {
        if(transform.position.y <-11)
        {
            dyingSoundEffect.Play();           
            Invoke("RestartLevel", 1f);          
        }
    }

    public override void GetDamage()
    {
        hitEnemySoundEffect.Play();
        lives -= 1;
        hearts[lives].enabled = false;       
        if (lives <= 0)
        {
            dyingSoundEffect.Play();
            Invoke("RestartLevel", 1f);            
        }
    }

    public void GetScore()
    {
        collectSoundEffect.Play();
        this.score += 10;
        this.coinsCount += 1;
       // scoreUI.text = this.score.ToString();
    }

    public void AddLife()
    {
        if (this.lives < 5)
        {
            collectSoundEffect.Play();
            this.lives += 1;
            hearts[lives - 1].enabled = true;
        }
    }

    public void AddJumpingPower()
    {
        collectSoundEffect.Play();
        this.jumpForce += 7f;
    }

    public void RestartLevel()
    {       
        UnityEngine.Debug.Log("RESTARTING GAME!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

public enum States
{
    Player_idle,
    Player_run,
    Player_jump
}