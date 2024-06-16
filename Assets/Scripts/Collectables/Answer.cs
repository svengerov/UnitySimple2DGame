using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            UnityEngine.Debug.Log("right answer!");
            Hero.Instance.GetScore();
            Hero.Instance.AddJumpingPower();
            Destroy(this.gameObject);
            UnityEngine.Debug.Log(this.gameObject.name);
        }
    }
}
