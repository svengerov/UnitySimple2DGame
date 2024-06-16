using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Hero.Instance.gameObject)
        {
            UnityEngine.Debug.Log(collision.gameObject.name);
            
            Hero.Instance.GetDamage();
        }
    }
}
