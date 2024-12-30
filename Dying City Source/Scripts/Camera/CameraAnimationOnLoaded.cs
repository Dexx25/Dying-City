using UnityEngine;
using System.Collections;

public class CameraAnimationOnLoaded : MonoBehaviour
{
    public Transform targetPosition; // The target position for the camera (X-axis will be used)
    private Vector3 initialCamPos; // Store the camera's initial position
    public float forwardTweenDuration = 2f; // Duration of the forward tween animation
    public float backTweenDuration = 1f; // Duration of the backward tween animation
    private CameraFollowPlayer CamFolow;
    private PlayerMovement Pmovement;

    private void Start()
    {
        // Store the initial position of the camera
        initialCamPos = transform.position;
        CamFolow = GetComponent<CameraFollowPlayer>();
        Pmovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (targetPosition != null)
        {
            // Start the coroutine to tween to the target position and back
            StartCoroutine(TweenToAndBack(targetPosition.position.x));
        }
        else
        {
            Debug.LogError("Target position not set for the camera tween!");
        }
    }

    private IEnumerator TweenToAndBack(float targetX)
    {
        // Tween to the target X position (forward tween)
        yield return TweenToX(targetX, forwardTweenDuration);

        // Wait for a short delay (optional)
        yield return new WaitForSeconds(0.5f);

        // Tween back to the original X position (faster back tween)
        yield return TweenToX(initialCamPos.x, backTweenDuration);
    }

    private IEnumerator TweenToX(float targetX, float duration)
    {
        float startX = transform.position.x;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Interpolate the X position while keeping Y and Z unchanged
            float newX = Mathf.Lerp(startX, targetX, elapsedTime / duration);
            transform.position = new Vector3(newX, initialCamPos.y, initialCamPos.z);

            yield return null; // Wait for the next frame
        }

        // Ensure the camera reaches the exact target X position
        transform.position = new Vector3(targetX, initialCamPos.y, initialCamPos.z);
        CamFolow.enabled = true;
        Pmovement.enabled = true;
    }
}
