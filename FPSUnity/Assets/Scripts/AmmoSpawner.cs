using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawners;
    [SerializeField] private GameObject ammoPrefab;

    private void Start()
    {
        for (int i = 0; i < spawners.Count; ++i)
        {
            GameObject newAmmo = Instantiate(ammoPrefab, spawners[i].position, transform.rotation, transform);
        }
    }
}
