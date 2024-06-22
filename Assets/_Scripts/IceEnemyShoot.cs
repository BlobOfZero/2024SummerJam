using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemyShoot : MonoBehaviour
{
    public GameObject iceProj;
    public Transform projPos;
    public float fireRate;
    public float shootDistance;


    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < shootDistance)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                ShootProj();
                timer = 0;
            }
        }


    }
    void ShootProj()
    {
        Instantiate(iceProj, projPos.position, Quaternion.identity);
    }
}
