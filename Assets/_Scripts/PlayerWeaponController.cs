using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject iceProjectile;
    [SerializeField] private GameObject fireProjectile;
    [SerializeField] private GameObject projectileSpawn;

    [SerializeField] private float weaponCooldown = 0.1f;
    private bool onCooldown = false;

    public void OnFireAttack(InputAction.CallbackContext context)
    {
        if (context.started && onCooldown == false)
        {
            Instantiate(fireProjectile, projectileSpawn.transform.position, fireProjectile.transform.rotation);
            Debug.Log("FIRE ATTACK");
            StartWeaponCooldown();
        }
    }

    public void OnIceAttack(InputAction.CallbackContext context)
    {
        if (context.started && onCooldown == false)
        {
            Instantiate(iceProjectile, projectileSpawn.transform.position, iceProjectile.transform.rotation);
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
