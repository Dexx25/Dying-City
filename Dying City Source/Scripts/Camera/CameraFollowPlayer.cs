using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float boundaryX = 5f; // check if bigger than this 

    private void Start()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogError("No object with tag 'Player' found. Please assign the player Transform.");
            }
        }
    }

    private void LateUpdate()
    {
        if (player == null) return;


        Vector3 targetPosition = transform.position;
        float playerX = player.position.x;
        if (Mathf.Abs(playerX - transform.position.x) > boundaryX)
        {
            targetPosition.x = Mathf.Floor(playerX);
        }

        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;

        // set to the new position
        transform.position = targetPosition;
    }
}
