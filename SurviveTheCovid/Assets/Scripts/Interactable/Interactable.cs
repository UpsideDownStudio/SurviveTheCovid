using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	public virtual void Interact()
    {
        Debug.Log("You interact with: " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
	    if (other.CompareTag("Player"))
	    {
            Interact();
	    }
    }
}
