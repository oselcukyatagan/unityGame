using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public Transform enemy;
    


    private void Update()
    {
        if (player != null && enemy != null)
            transform.position = new Vector3((player.position.x + enemy.position.x) / 2, transform.position.y, transform.position.z);
        
        if (player == null && enemy != null)
            transform.position = new Vector3(enemy.position.x, transform.position.y, transform.position.z);

        if (player != null && enemy == null)
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        if (player == null && enemy == null)
            transform.position = new Vector3(0, 0, 0);
    }


}
