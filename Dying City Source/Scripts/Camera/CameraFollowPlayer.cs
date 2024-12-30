using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float boundaryX = 5f; // Boundary for triggering camera adjustment on the X-axis

    private void Start()
    {
        if (player == null)
        {
            // Find the player object by tag if not manually assigned
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

        // Check if the player is outside the X boundary
        if (Mathf.Abs(playerX - transform.position.x) > boundaryX)
        {
            // Immediately center the camera's X position on the player
            targetPosition.x = Mathf.Floor(playerX);
        }

        // Keep the camera's Y and Z positions fixed
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;

        // Apply the new position
        transform.position = targetPosition;
    }
}
