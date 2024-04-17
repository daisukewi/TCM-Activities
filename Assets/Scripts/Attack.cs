using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 2;
    public LayerMask enemyLayer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DoAttack();
        }
    }

    void DoAttack()
    {
        // Play an attack animation

        // Dettect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Damage hit enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Health healthComponent = enemy.gameObject.GetComponent<Health>();
 
            if (healthComponent)
            {
                healthComponent.ApplyDamage(attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
