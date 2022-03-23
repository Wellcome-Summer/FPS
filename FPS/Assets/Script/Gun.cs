using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//만약 마우스 왼쪽 버튼을 누르면
//메인카메라가 바라본곳에 총알자국을 남기고싶다.
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
        //만약 마우스 왼쪽 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            //메인카메라가 바라본곳에 총알자국을 남기고싶다.
            //시선, 바라보다, 닿은 곳 정보
            //메인카메라의 위치에서 메인카메라의 앞방향으로 시선을 만들고싶다.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);//<레이캐스트 외워 구문임)

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //총알자국을 부딪힌곳에 남기고싶다.
                GameObject bImpact = Instantiate(bImpactFactory);
                bImpact.transform.position = hitInfo.point;
                bImpact.transform.forward = hitInfo.normal;
            }
        }


    }
}
