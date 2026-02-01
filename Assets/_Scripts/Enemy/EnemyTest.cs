using System.Collections;
using Dreamteck.Forever;
using Player.Core;
using Unity.VisualScripting;
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
        Debug.Log("hasar alıyor: " + health);
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void TriggerAttackAnim()
    {
        enemyAnimator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var playerBehaviour = other.gameObject.GetComponent<PlayerBehaviour>();
        if (playerBehaviour == null) return;
        
        playerBehaviour.Stats.Damage(5);
        enemycollider.enabled = false;
    }
}
