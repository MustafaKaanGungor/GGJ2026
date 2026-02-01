using UnityEngine;

public class MaskChest : MonoBehaviour
{
    [SerializeField] private GameObject maskBehaviourPrefab;
    [SerializeField] private GameObject breakEffect;
    public void SpawnMask()
    {
        Instantiate(maskBehaviourPrefab, transform.position, Quaternion.identity);
        //Instantiate(breakEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
