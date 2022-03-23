using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    public Enemy enemy; //        .GetComponentParent<Enemy>();


    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnEenemyAttackHit()
    {
        //���� Hit�� �Ǵ� ����
        enemy.OnEnemyAttackHit();

    }
    public void OnEenemyAttackFinished()
    {
        //���� �ִϸ��̼��� ����Ǵ� ����
        enemy.OnEnemyAttackFinished();

    }

}
