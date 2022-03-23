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
        //공격 Hit가 되는 순간
        enemy.OnEnemyAttackHit();

    }
    public void OnEenemyAttackFinished()
    {
        //공격 애니메이션이 종료되는 순간
        enemy.OnEnemyAttackFinished();

    }

}
