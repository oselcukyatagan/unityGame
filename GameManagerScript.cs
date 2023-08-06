using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverObject;

    public void GameOver()
    {
        StartCoroutine(ActivateGameOverAfterDelay(2f));
    }

    private IEnumerator ActivateGameOverAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        gameOverObject.SetActive(true);
    }
}
