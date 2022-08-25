using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D : MonoBehaviour
{
    public Player p;

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            p.downon = true;
            p.lefton = false;
            p.righton = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            p.downon = false;
        }
    }
}
