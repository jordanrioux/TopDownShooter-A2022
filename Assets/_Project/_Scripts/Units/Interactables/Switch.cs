using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Units.Players;
using UnityEngine;
using UnityEngine.Assertions;

namespace TopDownShooter.Units.Interactables
{
    public class Switch : BaseInteractable
    {
        [SerializeField] private BaseInteractable interactable;
        
        public override void Interact()
        {
            interactable.Interact();
        }
    }
}
