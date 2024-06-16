using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Monster : Entity
{
    [SerializeField] private float speed = 1f;
    private Vector3 direction;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform player;

    private void Awake()
    {       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * direction.x * 1f * speed, 0.1f);
        //    if (colliders.Length > 0) direction *= -1f;
        //   transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject == Hero.Instance.gameObject) 
        {
            Hero.Instance.GetDamage();
        }
    }



}
