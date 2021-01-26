using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    [SerializeField] Transform swordPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float attackRate = 2f;
    [SerializeField] float attackDamage;
    private Animator animator;
    private System.Random rnd = new System.Random();
    private int attackState;
    private float nextAttackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack(){
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F)){                
                Collider2D[] enemies = Physics2D.OverlapCircleAll(swordPoint.position, attackRange, enemyLayer);
                foreach(Collider2D enemy in enemies){
                    enemy.GetComponent<EnemyHealthSystem>().TakeDamage(attackDamage);
                }
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void OnDrawGizmosSelected() {
        if (swordPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(swordPoint.position, attackRange);
    }

    public int AttackStateShuffle(){
        attackState = rnd.Next(1,2);
        return attackState;
    }
}
