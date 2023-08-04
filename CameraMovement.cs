using JetBrains.Annotations;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    

    private void Update()
    {
        
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }


}
