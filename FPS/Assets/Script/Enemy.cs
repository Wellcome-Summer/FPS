using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//agent����� �̿��ؼ� �������� ���ؼ� �̵��ϰ�ʹ�.
//��ǥ�˻�, �̵�, ����
public class Enemy : MonoBehaviour
{
    //������ - �ڵ����� �ȿ� ���� ä����.(���������δ� int) ���콺 �÷����� Ȯ�� ����
    enum State
    {
        SEARCH,
        MOVE,
        ATTACK
    }


    // �������
    State state; //�Ƚ��൵ ����Ʈ�� 0. int state = 0;


    NavMeshAgent agent;
    GameObject target;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        state = State.SEARCH; //���� ���ۻ��´� ��ġ��.

        //this(GameObject) ���� ������Ʈ ������ <> �̰� => �� agent��� �Ѵ�.
        agent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            //if������ ����ġ���� ����. 

            //���� ���� ���°� ��ǥ�˻��̶�� �˻��� �ϰ�ʹ�.
            //(���� ��ġ�� ��������� �����ϰ� �״��� ���Ͷ�.)
            case State.SEARCH: UpdateSearch(); break;
            //�׷��� �ʰ� ���°� �̵��̶�� �̵��� �ϰ�ʹ�.
            case State.MOVE: UpdateMove(); break;
            //�׷��� �ʰ� ���°� �̵��̶�� �̵��� �ϰ�ʹ�.
            case State.ATTACK:UpdateAttack();break;
        }

    }

    private void UpdateAttack()
    {
        //dkfockawh.OnEnemy~~~
        

    }

    private void UpdateMove()
    {
        //������Ʈ���� ������(destination)�� "���" �˷��ְ�ʹ�.:���� �������� Ÿ���� ��ġ��.
        agent.destination = target.transform.position;
        //���� ���������� �Ÿ��� <= ���ݰ��� �Ÿ����?
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <= agent.stoppingDistance)
        {
            //���ݻ��·� �����ϰ�ʹ�.
            state = State.ATTACK;
            anim.SetTrigger("Attack");
            
        }


    }

  
    private void UpdateSearch()
    {
        //1. �������� ã��ʹ�.
        //���ӿ�����Ʈ�� �÷��̾� ã����=>�� Ÿ���̶�� �Ѵ�.
        target = GameObject.Find("Player"); //������ġ : start

        //2. ���� �������� ã������
        if(target != null)
        {
            //�̵����·� �����ϰ�ʹ�.
            state = State.MOVE;
            anim.SetTrigger("Move"); //trigger - �Ķ���� �̸����� ����
        }



    }

    //<EAE���� �޼��������: //���� Hit/Finished�� �Ǵ� ����>
    public void OnEnemyAttackHit() //internal �� public
    {
        //���� ���ݰ����� �Ÿ���� Hit�ϰ�ʹ�.
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            HitManager.instance.DoHitPlz();
        }

    }

    public void OnEnemyAttackFinished()
    {

        //���� ���������� �Ÿ��� ���ݰ����� �Ÿ��� �ƴ϶��
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > agent.stoppingDistance)
        {
            state = State.MOVE;
            anim.SetTrigger("Move");
        }
        //�ٽ� �̵����·� �����ϰ�ʹ�.
    }

}
