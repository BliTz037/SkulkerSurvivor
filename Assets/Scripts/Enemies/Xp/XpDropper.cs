using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpDropper : MonoBehaviour
{
    public GameObject XpPrefab;

    private List<GameObject> _spawnedXps;

    public void Awake()
    {
        _spawnedXps = new List<GameObject>();
    }

    public void DropXp(Vector3 position)
    {
        var xp = Instantiate(XpPrefab, position, Quaternion.identity);
        _spawnedXps.Add(xp);
    }

    public void Reset()
    {
        foreach (var xp in _spawnedXps)
        {
            Destroy(xp);
        }
        _spawnedXps.Clear();
    }
}
