using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Units.Interactables;
using TopDownShooter.Units.Players;
using UnityEngine;

namespace TopDownShooter.Units.Interactables
{
    public class Interaction : MonoBehaviour
    {
        protected bool Interactable { get; private set; }
        protected IInteractable InteractableObject { get; private set; }
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IInteractable>(out var interactable))
            {
                Interactable = true;
                InteractableObject = interactable;
            }
        }

        protected void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent<IInteractable>(out _))
            {
                Interactable = false;
                InteractableObject = null;
            }
        }
    }
}
