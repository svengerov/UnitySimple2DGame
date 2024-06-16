using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            collision.gameObject.transform.SetParent(transform); //set to player the transform of platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            collision.gameObject.transform.SetParent(null); //player can go himself when he gets out of platform
        }
    }
}
