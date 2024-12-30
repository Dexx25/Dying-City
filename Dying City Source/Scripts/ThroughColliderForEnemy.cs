using UnityEngine;

public class ThroughColliderForEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Ignore the collision between the "Enemy" and this collider
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), true);
        }
        // If the object is tagged "Player"
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Ensure the collision is not ignored for "Player"
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>(), false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If it's a trigger, do the same logic as OnCollisionEnter for trigger-based detection
        if (other.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>(), true);
        }
        else if (other.CompareTag("Player"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>(), false);
        }
    }
}
