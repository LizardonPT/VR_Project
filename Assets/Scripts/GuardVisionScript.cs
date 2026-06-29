using UnityEngine;

public class GuardVisionScript : MonoBehaviour
{
    public Transform visionOrigin;
    public float visionDistance;
    public float visionAngle;
    public Transform target;

    public Color defaultColor;
    public Color canSeeColor;

    public LayerMask visionMask;
    public float sphereCastRadius = 0.2f;

    private bool canSeeTarget = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool currentCanSeeTarget = CanSeeTarget();
        if (!canSeeTarget && currentCanSeeTarget)
        {
            GameManagerScript.singleton.GameOver();
        }
        canSeeTarget = currentCanSeeTarget;
    }

    public bool CanSeeTarget()
    {
        Vector3 directionToTarget = target.position - visionOrigin.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget > visionDistance)
            return false;

        float angleToTarget = Vector3.Angle(visionOrigin.forward, directionToTarget);
        if (angleToTarget > visionAngle / 2f)
        {
           return false; 
        }

        if(Physics.SphereCast(visionOrigin.position, sphereCastRadius, directionToTarget.normalized, out RaycastHit hit, directionToTarget.magnitude, visionMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.transform != target)
            {
                return false;
            }
        }

        return true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = canSeeTarget ? canSeeColor : defaultColor;
        UnityEditor.Handles.DrawSolidArc(visionOrigin.position, visionOrigin.up, visionOrigin.forward, visionAngle / 2f, visionDistance);
        UnityEditor.Handles.DrawSolidArc(visionOrigin.position, -visionOrigin.up, visionOrigin.forward, visionAngle / 2f, visionDistance);
    }
#endif
}
