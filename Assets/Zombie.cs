using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
