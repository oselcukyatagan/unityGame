using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float enemyHealth = 100;
    public Animator enemyAnimator;
    public Rigidbody2D enemyBody;

    private float speed = 5;
    public float jumpStrength = 10;
    public float horizontalMovement = 0;

    private float animationTime = 1.4f;


    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        EnemyMovement();
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

    private void EnemyMovement()
    {
        horizontalMovement = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            horizontalMovement = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontalMovement = 1f;

        if(horizontalMovement < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (horizontalMovement > 0)
            transform.localScale = new Vector3(1, 1, 1);


        if (Input.GetKey(KeyCode.UpArrow))
            enemyBody.velocity = new Vector2(0, jumpStrength);
            


        Vector2 move = new Vector2(speed * horizontalMovement * Time.deltaTime, 0);

        transform.Translate(move);
        


    }



}
