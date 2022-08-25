using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    public Player p;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            if (!p.downon)
            {
                p.sideon = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            if (!p.downon)
            {
                p.righton = true;
                p.grounded = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            p.righton = false;
            p.sideon = false;
        }
    }
}
