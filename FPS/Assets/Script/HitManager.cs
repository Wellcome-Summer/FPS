using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//화면이 번쩍거리는(ImageHit 게임오브젝트를 보였다가 0.1초후에 안보이게하는) 기능을 만들고싶다.


public class HitManager : MonoBehaviour
{
    //싱글톤으로 만드세요!!
    public static HitManager instance;
    private void Awake()
    {
        //this 클래스로 만들어진 자기 자신
        instance = this;
    }

    public GameObject imageHit;



    // Start is called before the first frame update
    void Start()
    {
        imageHit.SetActive(false);   //태어났어 근데 보이진 않아 false
    }
    //화면이 번쩍거리는(ImageHit 게임오브젝트를 보였다가 0.1초후에 안보이게하는) 기능을 만들고싶다.
    public void DoHitPlz() //코르틴함수 : 컴포넌트가 있는 함수에서만 쓸 수 있음
    {
        StopCoroutine("IEDoHit"); //여러명이 때렸을때 하나만 뜨게
        StartCoroutine("IEDoHit"); 

    }
    IEnumerator IEDoHit() //코르틴함수의 반환값 무조건!!!!!!!!!
    {

        //for (; ; :무한반복) = 내부 반복, 보였다 안보였다 무한반복하게 됨 
        //{


        //보이게한다.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.2f); //yield 양보...?, 0(= null)로 하면 최대한 빠르게 돌아옴.
        //보이게한다.
        imageHit.SetActive(false);


        //}

    }


// Update is called once per frame
void Update()
{

}
}
