using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Trigger : MonoBehaviour
{
    public event Action OnEnterTrigger;
    public event Action OnExitTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent(typeof(Player)))
            OnEnterTrigger.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent(typeof(Player)))
            OnExitTrigger.Invoke();
    }
}
