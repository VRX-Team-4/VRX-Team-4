using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    // Properties

    // Methods
    HoverOutput Hover();
    InteractionOutput Interact();
}
