using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            UnityEngine.Debug.Log("collect coin!");
            Hero.Instance.GetScore();
            Destroy(this.gameObject);
            UnityEngine.Debug.Log(this.gameObject.name);
        }
    }
}
