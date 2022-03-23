using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//agent기능을 이용해서 목적지를 향해서 이동하고싶다.
//목표검색, 이동, 공격
public class Enemy : MonoBehaviour
{
    //열거형 - 자동으로 안에 값이 채워짐.(내부적으로는 int) 마우스 올려보면 확인 가능
    enum State
    {
        SEARCH,
        MOVE,
        ATTACK
    }


    // 현재상태
    State state; //안써줘도 디폴트값 0. int state = 0;


    NavMeshAgent agent;
    GameObject target;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        state = State.SEARCH; //너의 시작상태는 서치야.

        //this(GameObject) 나야 컴포넌트 가져워 <> 이거 => 를 agent라고 한다.
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            //if문보다 스위치문이 빠름. 

            //만약 현재 상태가 목표검색이라면 검색만 하고싶다.
            //(만약 서치가 들어있으면 진행하고 그다음 나와라.)
            case State.SEARCH: UpdateSearch(); break;
            //그렇지 않고 상태가 이동이라면 이동만 하고싶다.
            case State.MOVE: UpdateMove(); break;
            //그렇지 않고 상태가 이동이라면 이동만 하고싶다.
            case State.ATTACK:UpdateAttack();break;
        }

    }

    private void UpdateAttack()
    {
        //dkfockawh.OnEnemy~~~
        

    }

    private void UpdateMove()
    {
        //에이전트에게 목적지(destination)를 "계속" 알려주고싶다.:너의 목적지는 타겟의 위치야.
        agent.destination = target.transform.position;
        //만약 목적지와의 거리가 <= 공격가능 거리라면?
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <= agent.stoppingDistance)
        {
            //공격상태로 전이하고싶다.
            state = State.ATTACK;
            anim.SetTrigger("Attack");
            
        }


    }

  
    private void UpdateSearch()
    {
        //1. 목적지를 찾고싶다.
        //게임오브젝트야 플레이어 찾아줘=>를 타겟이라고 한다.
        target = GameObject.Find("Player"); //원래위치 : start

        //2. 만약 목적지를 찾았으면
        if(target != null)
        {
            //이동상태로 전이하고싶다.
            state = State.MOVE;
            anim.SetTrigger("Move"); //trigger - 파라미터 이름으로 기재
        }



    }

    //<EAE에서 메서드생성함: //공격 Hit/Finished가 되는 순간>
    public void OnEnemyAttackHit() //internal → public
    {
        //만약 공격가능한 거리라면 Hit하고싶다.
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            HitManager.instance.DoHitPlz();
        }

    }

    public void OnEnemyAttackFinished()
    {

        //만약 목적지와의 거리가 공격가능한 거리가 아니라면
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > agent.stoppingDistance)
        {
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
        //다시 이동상태로 전이하고싶다.
    }

}
