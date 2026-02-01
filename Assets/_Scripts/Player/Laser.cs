using UnityEngine;

public class Laser : MonoBehaviour
{
    
    void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<EnemyTest>(out EnemyTest enemy))
        {
            enemy.DealDamage(10);
        } 

        if(other.TryGetComponent<MaskChest>(out MaskChest chest))
        {
            chest.SpawnMask();
        }   
    }
}
