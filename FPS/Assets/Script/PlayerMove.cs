using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������� �Է¿� ���� �յ� �¿�� �̵��ϰ� �ʹ�.
//������ �ٰ�ʹ�~~
//�ٴ���, �߷�, y�ӵ�
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    public float jumpPower = 10;//�ٴ���, �뷱���ϱ� �ۺ�����
    public float gravity = -9.81f;//�߷�, �÷��̸� ��, ȭ������ �� ���� �����ϱ� ���������ϰ�
    float yVelocity;
    //���� ������ �ٰ�ʹ�.
    int jumpCount;
    public int maxjumpCount = 2;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>(); //gameObject�� ��������, <>�ȿ� �־�°� ���׸� or ���ø��̶�� �θ�
                                                             //���׸�(Generic)�� ���� ��ȯ�ڷᰡ �ٲ�. �����߿� <>������ �׶��׶� ������. ->���ͳݰ˻��ʿ�!
    }

    // Update is called once per frame
    void Update()
    {

        //1) y�ӵ��� �߷��� ��� �޾ƾ��Ѵ�(-9.81m/sec). ->y�ӵ��� �߷��� ��� �����ش� �� ����.(�ʴ�)
       
        //�׳� �׷���Ƽ���� �ϸ� �� �����Ӹ��� �������°����� ��Ÿ������ �������ν� �� �ʸ��� �������°ɷ� �ٲ�,

        //��)���� ���� ���ִٸ� -> ������ ������ ������ ���� �Ʒ� ��2)�� ����
        // if(cc.isGrounded)
        //   {
        //       yVelocity = 0;
        //   }


        if (cc.isGrounded)
        {
            //���� �� �ִٸ� ����Ƚ���� 0���� �ʱ�ȭ�ϰ�ʹ�.
            jumpCount = 0;
        }
        //���� �����̶��
        else
        {
            //��2) �ӵ��� ���߿��� �߷��� ��� �޾ƾ��Ѵ�. -9.81m/sec
            yVelocity += gravity * Time.deltaTime;
        }

        //��)yVelocity�� 0���� �ϰ�ʹ�. <-�����ؼ� ��ü �ö󰬴� �����ö� �Ҷ����� ���� �ذ�

        //2-1) ���� ���� ���ְ� ����Ű�� ������ y�ӵ��� jumpPower(�ٴ���)�� �ϰ�ʹ�.
        //if (cc.isGrounded && Input.GetButtonDown("Jump"))
        //{
        //    yVelocity = jumpPower;
        //}


        //2-2) ���� ����Ƚ���� �ִ�����Ƚ������ �۰�� ����Ű�� ������ y�ӵ��� jumpPower(�ٴ���)�� �ϰ�ʹ�.
        if (jumpCount < maxjumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }

        //1.������� �Է¿�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //2,�յ��¿�� ������ �ݵ��
        //Vector3 dir2 = Vector3.right * h * Vector3.forward * v;
        Vector3 dir = new Vector3(h, 0, v);

       

        //����(dir)�� ī�޶� �������� �����ϰ�ʹ�
        dir = Camera.main.transform.TransformDirection(dir);
        //ī�޶�� ����ī�޶� �� ��.���ξ� ������ ��->������ ���� ����(����)�� �ڱ� ����(ī�޶�)���� ��ȯ�ؼ� ��ȯ��.
        dir.y = 0; //���� �� y������ �Ű����� �ʰ�. �ϴ÷� �鸮�� ������ �������°�X
        dir.Normalize();
        Vector3 velocity = dir * speed; //��
        //3)�̵������� y�Ӽ�(dir(�������ϴ¹���direction)�� y)�� y�ӵ��� �����ϰ�ʹ�.
        velocity.y = yVelocity; //��

        //4.�� �������� �̵��ϰ�ʹ�.
        cc.Move(velocity * Time.deltaTime); //cc�� �׳� vt�� �������. �����ִ¸�ŭ�� ���� ��ü�� ������ ����
        //cc.Move(dir * speed * Time.deltaTime); �̷��� �ϸ� �̹� �ִ� �ӵ� dir�� ���ǵ�� ���ؼ� �� ���� �ٰ� ��.
        //��) �� ��)�� �����ؼ� ������ �ٲ� �� ��Ȳ�� ������.

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        Vector3 from = transform.position;
        Vector3 to = transform.position + Vector3.up * yVelocity;
        Gizmos.DrawLine(from, to);
    }
}
