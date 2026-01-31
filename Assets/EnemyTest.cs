using Dreamteck.Forever;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private LevelSegment levelSegment;
    private float currentDistance = 1f; 
    void Start()
    {
        levelSegment = GetComponentInParent<LevelSegment>();
    }

    void Update()
    {
        if(levelSegment.activated)
        {
            transform.position = levelSegment.path.spline.EvaluatePosition(currentDistance);
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
            currentDistance -= Time.deltaTime * 0.2f;
        }
        
    }
}
