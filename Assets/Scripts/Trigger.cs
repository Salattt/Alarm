using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Trigger : MonoBehaviour
{
    public event Action EnterTrigger;
    public event Action ExitTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent(typeof(Player)))
            EnterTrigger.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent(typeof(Player)))
            ExitTrigger.Invoke();
    }
}
