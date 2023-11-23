using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator animator; // Assign this in the inspector
    public string startTriggerName = "StartAnimation"; // Name of the trigger parameter to start the animation
    public string stopBoolName = "StopAnimation"; // Name of the bool parameter to stop the animation

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to trigger the animation after 5 seconds
        StartCoroutine(TriggerAnimationAfterDelay(5f));
    }

    private IEnumerator TriggerAnimationAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        
        // Trigger the animation to start
        animator.SetTrigger(startTriggerName);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click to stop the animation
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            // Set the bool parameter to true to stop the animation
            animator.SetBool(stopBoolName, true);
        }
    }
}
