using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoOb : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
