using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBulletPrefab;
    public GameObject iceBulletPrefab;
    public float weaponCooldown;
    [SerializeField] private bool onCooldown;

    public void OnFireAttack(InputAction.CallbackContext context)
    {
        if (context.started && onCooldown == false)
        {
            Instantiate(fireBulletPrefab, firePoint.position, firePoint.rotation);

            Debug.Log("FIRE ATTACK");
            StartWeaponCooldown();
        }
    }

    public void OnIceAttack(InputAction.CallbackContext context)
    {
        if (context.started && onCooldown == false)
        {
            Instantiate(iceBulletPrefab, firePoint.position, firePoint.rotation);
            Debug.Log("ICE ATTACK");
            StartWeaponCooldown();
        }
    }

    private void StartWeaponCooldown()
    {
        onCooldown = true;
        Invoke("ResetCooldown", weaponCooldown); // Start the cooldown timer
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
