using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject iceProjectile;
    [SerializeField] private GameObject fireProjectile;
    [SerializeField] private GameObject projectileSpawn;
    private float projectileSpawnDistance = 1.5f;

    [SerializeField] private float weaponCooldown = 0.1f;
    private bool onCooldown = false;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        // Calculate angle based on mouse direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Limit angle to prevent spawning beyond vertical
        if (Mathf.Abs(angle) > 90f)
        {
            angle = Mathf.Sign(angle) * 90f; // Clamp angle to be within -90 to +90 degrees
        }

        // Set rotation of projectileSpawn object
        projectileSpawn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Calculate position based on limited angle
        projectileSpawn.transform.position = transform.position + Quaternion.Euler(0, 0, angle) * Vector3.right * projectileSpawnDistance;
    }

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
