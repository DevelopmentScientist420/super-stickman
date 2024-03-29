using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : Interactable
{
    [SerializeField] private GameObject door;
    
    protected override void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        door.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
