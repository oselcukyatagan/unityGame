using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float enemyHealth = 100;
    public Animator enemyAnimator;
    public Rigidbody2D enemyBody;

    private float animationTime = 1.4f;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        
    }

    public void enemyTakeDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject, animationTime);
        enemyAnimator.SetTrigger("EnemyDieTrigger");
    }

}
