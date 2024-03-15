using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Alteruna.Avatar avatar;
    public GameObject orintation;
    private float range = 100f;
    private float damage = 5f;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponentInParent<Alteruna.Avatar>();
        if (!avatar.IsMe)
        {
            return;
        }
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward,out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null) 
            {
                target.takeDamage(damage);
            }
        }
    }
}
