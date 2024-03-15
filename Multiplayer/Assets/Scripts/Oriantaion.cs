using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oriantaion : MonoBehaviour
{
    private Alteruna.Avatar avatar;
    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponentInParent<Alteruna.Avatar>();
        if(!avatar.IsMe)
        {
            return;
        }
        transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }
        transform.position = Camera.main.transform.position;
    }
}
