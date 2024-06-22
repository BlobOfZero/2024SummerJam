using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemyShoot : MonoBehaviour
{
    public GameObject iceProj;
    public Transform projPos;
    public float fireRate;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if ( timer > fireRate ) 
        {
            timer = 0;
            ShootProj();
        }
    }
    void ShootProj()
    {
        Instantiate(iceProj, projPos.position, Quaternion.identity);
    }
}
