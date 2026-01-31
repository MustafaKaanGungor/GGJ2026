using UnityEngine;
using Dreamteck.Forever;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    private LevelSegment segment;
    private WaveType waveType;
    private bool isEnemiesSpawned = false;
    [SerializeField] private GameObject enemyPrefab;
    private List<Vector3> spawnPositions = new List<Vector3>();
    private GameObject tempEnemy;
    private float currentDistance = 1f;

    private void Start()
    {
        segment = GetComponentInParent<LevelSegment>();
        waveType = (WaveType)Random.Range(0, 5);
        segment.onActivate += OnSegmentActivated;
    }

    private void OnSegmentActivated(int obj)
    {
        Debug.Log("hyeo");
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

            isEnemiesSpawned = true;
        }
        

        
    }

    void Update()
    {
        
        if(isEnemiesSpawned)
        {
            transform.position = segment.path.spline.EvaluatePosition(currentDistance);
            currentDistance -= Time.deltaTime * 0.2f;
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