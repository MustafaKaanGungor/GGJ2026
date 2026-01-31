using UnityEngine;
using Dreamteck.Forever;
using System.Collections.Generic;
using System.Linq;
using Player.Core;

public class EnemySpawner : MonoBehaviour
{
    private LevelSegment segment;
    private WaveType waveType;
    private bool isEnemiesSpawned = false;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject tempEnemy;
    private float currentDistance = 1f;
    private float towardPlayerLerpRate = 0.03f;
    private List<EnemyTest> spawnedEnemies = new List<EnemyTest>();

    private void Start()
    {
        segment = GetComponentInParent<LevelSegment>();
        waveType = (WaveType)Random.Range(0, 5);
        segment.onActivate += OnSegmentActivated;
    }

    private void OnSegmentActivated(int obj)
    {
        if(!isEnemiesSpawned)
        {
            switch(waveType)
            {
                case WaveType.Line:
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(3, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(1, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-1, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-3, 3, 0);
                break;
                case WaveType.UpArrow:
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(3, 2.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(1.5f, 3f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(0, 3.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-1.5f, 3f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-3, 2.5f, 0);
                break;
                case WaveType.DownArrow:
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(3, 3.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(1.5f, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(0, 2.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-1.5f, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-3, 3.5f, 0);

                break;
                case WaveType.Dispersed:
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(3, 2.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(1.5f, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(0, 2.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-1.5f, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-3, 2.5f, 0);

                break;
                case WaveType.Bandolier:
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(3, 4f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(1.5f, 3.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(0, 3, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-1.5f, 2.5f, 0);
                tempEnemy = Instantiate(enemyPrefab, transform, false);
                tempEnemy.transform.localPosition = new Vector3(-3, 2f, 0);
                break;

                default:
                break;
            }

            spawnedEnemies = gameObject.GetComponentsInChildren<EnemyTest>().ToList();
            isEnemiesSpawned = true;
        }
        

        
    }

    void Update()
    {
        var distance = Vector3.Distance(transform.position, PlayerBehaviour.Instance.transform.position);
        if(isEnemiesSpawned)
        {
            transform.position = segment.path.spline.EvaluatePosition(currentDistance);
            currentDistance -= Time.deltaTime * 0.2f;
        } 
        
        if(distance <= 10.0f && isEnemiesSpawned)
        {   
            foreach(EnemyTest enemy in spawnedEnemies)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), towardPlayerLerpRate);
            }
        }
    }
}

public enum WaveType
{
    Line = 0,
    UpArrow = 1,
    DownArrow = 2,
    Dispersed = 3,
    Bandolier = 4
}