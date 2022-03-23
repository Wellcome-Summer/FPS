using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ȭ���� ��½�Ÿ���(ImageHit ���ӿ�����Ʈ�� �����ٰ� 0.1���Ŀ� �Ⱥ��̰��ϴ�) ����� �����ʹ�.


public class HitManager : MonoBehaviour
{
    //�̱������� ���弼��!!
    public static HitManager instance;
    private void Awake()
    {
        //this Ŭ������ ������� �ڱ� �ڽ�
        instance = this;
    }

    public GameObject imageHit;



    // Start is called before the first frame update
    void Start()
    {
        imageHit.SetActive(false);   //�¾�� �ٵ� ������ �ʾ� false
    }
    //ȭ���� ��½�Ÿ���(ImageHit ���ӿ�����Ʈ�� �����ٰ� 0.1���Ŀ� �Ⱥ��̰��ϴ�) ����� �����ʹ�.
    public void DoHitPlz() //�ڸ�ƾ�Լ� : ������Ʈ�� �ִ� �Լ������� �� �� ����
    {
        StopCoroutine("IEDoHit"); //�������� �������� �ϳ��� �߰�
        StartCoroutine("IEDoHit"); 

    }
    IEnumerator IEDoHit() //�ڸ�ƾ�Լ��� ��ȯ�� ������!!!!!!!!!
    {

        //for (; ; :���ѹݺ�) = ���� �ݺ�, ������ �Ⱥ����� ���ѹݺ��ϰ� �� 
        //{


        //���̰��Ѵ�.
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.2f); //yield �纸...?, 0(= null)�� �ϸ� �ִ��� ������ ���ƿ�.
        //���̰��Ѵ�.
        imageHit.SetActive(false);


        //}

    }


// Update is called once per frame
void Update()
{

}
}
