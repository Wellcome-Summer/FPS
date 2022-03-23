using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //alpha �� ��� Ű��, pad�� ����Ű�е�
        {
            //idle
            //anim.SetTrigger("Idle");
            anim.Play("Idle", 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            //Walk
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Attack
            anim.SetTrigger("Attack");
        }
    }
}
