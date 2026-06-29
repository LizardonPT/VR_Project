using UnityEngine;

public class GuardDeathScript : MonoBehaviour
{
    public Animator animator;
    public GuardVisionScript guardVision;
    public SimplePatrolScript guardPatrol;

    
    public void TriggerDeathAnimation()
    {
        animator.SetTrigger("Dead");
        guardVision.enabled = false;
        guardPatrol.enabled = false;
    }
}
