using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private GameObject iceProjectile;
    [SerializeField] private GameObject fireProjectile;
    [SerializeField] private GameObject projectileSpawn;

    public void OnFireAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Instantiate(fireProjectile, projectileSpawn.transform.position, fireProjectile.transform.rotation);
            Debug.Log("FIRE ATTACK");
        }
    }

    public void OnIceAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Instantiate(iceProjectile, projectileSpawn.transform.position, fireProjectile.transform.rotation);
            Debug.Log("ICE ATTACK");
        }
    }
}
