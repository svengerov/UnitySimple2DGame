using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LastQuestion : MonoBehaviour
{
    
    [SerializeField] private AudioSource finishSoundEffect;
    private bool isCompleted = false;

    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCompleted)
        {            
            finishSoundEffect.Play();
            Invoke("CompleteLevel", 2f);
            isCompleted = true;
            CompleteLevel();
            
        }
    }
    private void CompleteLevel()
    {
        UnityEngine.Debug.Log("finished!");
     
    }
}
