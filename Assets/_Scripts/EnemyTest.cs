using System.Collections;
using Dreamteck.Forever;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private LevelSegment levelSegment;
    private float currentDistance = 1f;
    [SerializeField] private float health = 100f;
    private MeshRenderer meshRenderer;
    private SphereCollider enemycollider;
    void Start()
    {
        levelSegment = GetComponentInParent<LevelSegment>();
        meshRenderer = GetComponent<MeshRenderer>();
        enemycollider = GetComponent<SphereCollider>();
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

    public void DealDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    private IEnumerator Dead()
    {
        meshRenderer.enabled = false;
        enemycollider.enabled = false;
        yield return new WaitForSeconds(1f); 
        gameObject.SetActive(false);
    }
}
