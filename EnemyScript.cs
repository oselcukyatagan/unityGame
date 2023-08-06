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

    public Transform enemyFirePoint;
    public GameObject fireball;

    public float fireCoolDown = 1;
    private float timer;

    public bool enemyWalking = false;
    public bool grounded = true;

    private bool enemyDead = false;
    public GameManagerScript gameManager;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        EnemyMovement();

        if (Input.GetKey(KeyCode.DownArrow) && timer >= fireCoolDown)
            EnemyFire();

        timer += Time.deltaTime;
        enemyAnimator.SetBool("enemyGroundedBool", grounded);
    }

    public void enemyTakeDamage(float damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0 && !enemyDead)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject, animationTime);
        enemyAnimator.SetTrigger("EnemyDieTrigger");
        enemyDead = true;
        gameManager.GameOver();
        
    }

    private void EnemyMovement()
    {

        // Calculate position and direction
        horizontalMovement = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            horizontalMovement = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            horizontalMovement = 1f;

        if(horizontalMovement < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (horizontalMovement > 0)
            transform.localScale = new Vector3(1, 1, 1);


        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            enemyBody.velocity = new Vector2(0, jumpStrength);
            grounded = false;
            enemyAnimator.SetTrigger("enemyJumpTrigger");
        }


        // Animation
        if (horizontalMovement == 0)
            enemyWalking = false;
        else
            enemyWalking = true;

        enemyAnimator.SetBool("enemyWalkingBool", enemyWalking);


        // Move

        Vector2 move = new Vector2(speed * horizontalMovement * Time.deltaTime, 0);

        transform.Translate(move);
        


    }

    private void EnemyFire()
    {
        enemyAnimator.SetTrigger("enemyFireTrigger");

        Instantiate(fireball, enemyFirePoint.position, enemyFirePoint.rotation);

        timer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
