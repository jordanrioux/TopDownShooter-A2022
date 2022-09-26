using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Units.Players;
using UnityEngine;

namespace TopDownShooter.Units.Interactables
{
    public abstract class BaseInteractable : MonoBehaviour, IInteractable
    {
        public abstract void Interact();

        // OU
        //
        // public virtual void Interact()
        // {
        //     Destroy(gameObject);
        // }
    }
}
