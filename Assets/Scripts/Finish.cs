using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private int level1Coins = 9;
    [SerializeField] private AudioSource finishSoundEffect;
    private bool isCompleted = false;

    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject && Hero.Instance.getCoinsCount() == level1Coins && !isCompleted)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
