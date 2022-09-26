using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Units.Interactables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter.Units.Players
{
    public class PlayerInteraction : Interaction
    {
        private void Update()
        {
            // FIXME: Keyboard is bad, use Input Component/Wrapper
            if (Interactable && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                InteractableObject.Interact();
            }
        }
    }
}
