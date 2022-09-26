using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace TopDownShooter.Units.Players
{
    public class PlayerAim : MonoBehaviour
    {
        [Header("Player Properties")]
        [SerializeField] private SpriteRenderer armRenderer;
        [SerializeField] private List<SpriteRenderer> characterRenderers;

        [Header("Weapon Properties")]
        [SerializeField] private AudioSource weaponAudio;
        [SerializeField] private float audioPitchRange;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform bulletSpawnerDirection;
        [SerializeField] private Transform weaponPivot;
        
        private Vector2 _currentMousePosition;
        private float _originalPitch;

        private void Start()
        {
            _originalPitch = weaponAudio.pitch;
        }

        public void OnShoot(InputValue value)
        {
            var t = bulletSpawnerDirection.transform;
            var bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.SetActive(true);

            PlayAudio();
        }
        
        private void PlayAudio()
        {
            if (weaponAudio.isPlaying)
            {
                weaponAudio.Stop();
            }
            weaponAudio.pitch = Random.Range(_originalPitch - audioPitchRange, _originalPitch + audioPitchRange);
            weaponAudio.Play();
        }
        
        private void Update()
        {
            _currentMousePosition = Mouse.current.position.ReadValue();
        }

        private void FixedUpdate()
        {
            RotateCharacterWeapon();
        }
        
        private void RotateCharacterWeapon()
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(_currentMousePosition);
            var newAim = (worldPosition - transform.position).normalized;
            RotateArm(newAim);
        }

        private void RotateArm(Vector2 newAimDirection)
        {
            var rotationZ = Mathf.Atan2(newAimDirection.y, newAimDirection.x) * Mathf.Rad2Deg;
            FlipCharacterBasedOnAimAngle(rotationZ);
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        private void FlipCharacterBasedOnAimAngle(float rotationZ)
        {
            armRenderer.flipY = Mathf.Abs(rotationZ) > 90f;
            foreach (var characterRenderer in characterRenderers)
            {
                characterRenderer.flipX = armRenderer.flipY;
            }
        }
    }
}
