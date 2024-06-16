using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            UnityEngine.Debug.Log("adding life!");
            Hero.Instance.AddLife();
            Destroy(this.gameObject);
        }
    }
}
