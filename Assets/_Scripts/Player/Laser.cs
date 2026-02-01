using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        

        if(other.TryGetComponent<MaskChest>(out MaskChest chest))
        {
            chest.SpawnMask();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<EnemyTest>(out EnemyTest enemy))
        {
            enemy.DealDamage(50);
        } 
    }

    void Update()
    {
        
    }

}
