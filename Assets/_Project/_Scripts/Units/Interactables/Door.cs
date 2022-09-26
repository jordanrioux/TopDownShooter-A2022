using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Units.Players;
using UnityEngine;

namespace TopDownShooter.Units.Interactables
{
    public class Door : BaseInteractable
    {
        [SerializeField] private Animator animator;

        #region Animator Fields
        
        private static readonly int Opened = Animator.StringToHash("Opened");
        
        #endregion
        
        public override void Interact()
        {
            animator.SetBool(Opened, true);
        }
    }
}
