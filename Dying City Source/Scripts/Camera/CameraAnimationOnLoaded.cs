using UnityEngine;
using System.Collections;

public class CameraAnimationOnLoaded : MonoBehaviour
{
    public Transform targetPosition;
        private Vector3 initialCamPos;
    public float forwardTweenDuration = 2f;
        public float backTweenDuration = 1f;
    private CameraFollowPlayer CamFolow;
    private PlayerMovement Pmovement;

    private void Start()
    {
        initialCamPos = transform.position;
            CamFolow = GetComponent<CameraFollowPlayer>();
        Pmovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (targetPosition != null)
        {
            StartCoroutine(TweenToAndBack(targetPosition.position.x));
        }
        else
        {
            Debug.LogError("Target position not set for the camera tween!");
        }
    }

    private IEnumerator TweenToAndBack(float targetX)
    {

        yield return TweenToX(targetX, forwardTweenDuration);
        yield return new WaitForSeconds(0.5f);

        yield return TweenToX(initialCamPos.x, backTweenDuration);
    }

    private IEnumerator TweenToX(float targetX, float duration)
    {

        float startX = transform.position.x;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newX = Mathf.Lerp(startX, targetX, elapsedTime / duration);
            transform.position = new Vector3(newX, initialCamPos.y, initialCamPos.z);
            yield return null;

        }
        transform.position = new Vector3(targetX, initialCamPos.y, initialCamPos.z);
        CamFolow.enabled = true;
        Pmovement.enabled = true;
    }
}
