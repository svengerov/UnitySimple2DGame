using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int worm_lives = 1;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;


    public static Worm Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    public override void GetDamage()
    {
        worm_lives -= 1;
       
        if (worm_lives<0)
        { Die(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            this.GetDamage();
        }
    }

}


