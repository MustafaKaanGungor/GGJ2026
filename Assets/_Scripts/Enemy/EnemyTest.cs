using System.Collections;
using Dreamteck.Forever;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private LevelSegment levelSegment;
    
    [SerializeField] private float health = 100f;
    private MeshRenderer meshRenderer;
    private SphereCollider enemycollider;
    public Vector3 offset;
    private Animator enemyAnimator;
    void Start()
    {
        levelSegment = GetComponentInParent<LevelSegment>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        enemycollider = GetComponentInChildren<SphereCollider>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(levelSegment.activated)
        {
            
        }
    }
    public void DealDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            gameObject.SetActive(false);
            /*meshRenderer.enabled = false;
        enemycollider.enabled = false;
            StartCoroutine(Dead());*/
        }
    }

    private IEnumerator Dead()
    {
        
        yield return new WaitForSeconds(1f); 
        
    }

    public void TriggerAttackAnim()
    {
        enemyAnimator.SetTrigger("Attack");
    }
}
