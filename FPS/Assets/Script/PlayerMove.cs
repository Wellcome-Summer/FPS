using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//사용자의 입력에 따라 앞뒤 좌우로 이동하고 싶다.
//점프를 뛰고싶다~~
//뛰는힘, 중력, y속도
public class PlayerMove : MonoBehaviour
{
    CharacterController cc;
    public float jumpPower = 10;//뛰는힘, 밸런스니까 퍼블릭으로
    public float gravity = -9.81f;//중력, 플레이를 달, 화성에서 할 수도 있으니까 조절가능하게
    float yVelocity;
    //다중 점프를 뛰고싶다.
    int jumpCount;
    public int maxjumpCount = 2;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>(); //gameObject는 생략가능, <>안에 넣어쓰는걸 제네릭 or 템플릿이라고 부름
                                                             //제네릭(Generic)에 따라 반환자료가 바뀜. 실행중에 <>에따라 그때그때 결정함. ->인터넷검색필요!
    }

    // Update is called once per frame
    void Update()
    {

        //1) y속도는 중력을 계쏙 받아야한다(-9.81m/sec). ->y속도에 중력을 계속 더해준다 매 순간.(초당)
       
        //그냥 그래비티까지 하면 매 프레임마다 더해지는거지만 델타다임을 곱함으로써 매 초마다 더해지는걸로 바뀜,

        //가)만약 땅에 서있다면 -> 점프가 씹히는 오류가 나서 아래 가2)로 변경
        // if(cc.isGrounded)
        //   {
        //       yVelocity = 0;
        //   }


        if (cc.isGrounded)
        {
            //땅에 서 있다면 점프횟수를 0으로 초기화하고싶다.
            jumpCount = 0;
        }
        //만약 공중이라면
        else
        {
            //가2) 속도는 공중에서 중력을 계속 받아야한다. -9.81m/sec
            yVelocity += gravity * Time.deltaTime;
        }

        //나)yVelocity를 0으로 하고싶다. <-점프해서 물체 올라갔다 내려올때 뚝떨어짐 현상 해결

        //2-1) 만약 땅에 서있고 점프키를 누르면 y속도를 jumpPower(뛰는힘)로 하고싶다.
        //if (cc.isGrounded && Input.GetButtonDown("Jump"))
        //{
        //    yVelocity = jumpPower;
        //}


        //2-2) 만약 점프횟수가 최대점프횟수보다 작고고 점프키를 누르면 y속도를 jumpPower(뛰는힘)로 하고싶다.
        if (jumpCount < maxjumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }

        //1.사용자의 입력에따라
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //2,앞뒤좌우로 방향을 반들고
        //Vector3 dir2 = Vector3.right * h * Vector3.forward * v;
        Vector3 dir = new Vector3(h, 0, v);

       

        //방향(dir)을 카메라를 기준으로 변경하고싶다
        dir = Camera.main.transform.TransformDirection(dir);
        //카메라야 메인카메라 좀 줘.메인아 방향좀 줘->위에서 받은 방향(로컬)을 자기 기준(카메라)으로 변환해서 반환함.
        dir.y = 0; //방향 중 y축으로 옮겨지지 않게. 하늘로 들리고 땅으로 내려가는거X
        dir.Normalize();
        Vector3 velocity = dir * speed; //①
        //3)이동방향의 y속성(dir(가고자하는방향direction)의 y)에 y속도를 대입하고싶다.
        velocity.y = yVelocity; //②

        //4.그 방향으로 이동하고싶다.
        cc.Move(velocity * Time.deltaTime); //cc는 그냥 vt만 넣으면됨. 갈수있는만큼만 가고 물체가 있으면 멈춤
        //cc.Move(dir * speed * Time.deltaTime); 이렇게 하면 이미 있는 속도 dir에 스피드는 더해서 더 높이 뛰게 됨.
        //가) 와 나)를 먼저해서 순서를 바꿔 그 상황을 없애줌.

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        Vector3 from = transform.position;
        Vector3 to = transform.position + Vector3.up * yVelocity;
        Gizmos.DrawLine(from, to);
    }
}
