using Unity.VisualScripting;
using UnityEngine;

public class PlayerGetAffected : MonoBehaviour
{

    public float playerHealth = 100;
    public Animator playerAnimator;
    


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

        if (playerHealth<= 0)
            enemyDie();
    }

    private void enemyDie() 
    {
        playerAnimator.SetTrigger("playerDieTrigger");
        Destroy(gameObject, 1f);
    }
}
