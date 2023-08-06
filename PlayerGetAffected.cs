using Unity.VisualScripting;
using UnityEngine;

public class PlayerGetAffected : MonoBehaviour
{

    public float playerHealth = 100;
    public Animator playerAnimator;

    public bool playerDead = false;
    public GameManagerScript gameManager;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }


    private void Update()
    {
        
    }

    public void enemyTakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0 && !playerDead)
            playerDie();
    }

    private void playerDie() 
    {
        playerAnimator.SetTrigger("playerDieTrigger");
        Destroy(gameObject, 1.4f);

        playerDead = true;
        gameManager.GameOver();

        
    }
}
