using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� ���콺 ���� ��ư�� ������
//����ī�޶� �ٶ󺻰��� �Ѿ��ڱ��� �����ʹ�.
public class Gun : MonoBehaviour
{
    public GameObject bImpactFactory;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���� ���콺 ���� ��ư�� ������
        if (Input.GetButtonDown("Fire1"))
        {
            //����ī�޶� �ٶ󺻰��� �Ѿ��ڱ��� �����ʹ�.
            //�ü�, �ٶ󺸴�, ���� �� ����
            //����ī�޶��� ��ġ���� ����ī�޶��� �չ������� �ü��� �����ʹ�.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);//<����ĳ��Ʈ �ܿ� ������)

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //�Ѿ��ڱ��� �ε������� �����ʹ�.
                GameObject bImpact = Instantiate(bImpactFactory);
                bImpact.transform.position = hitInfo.point;
                bImpact.transform.forward = hitInfo.normal;
            }
        }


    }
}
