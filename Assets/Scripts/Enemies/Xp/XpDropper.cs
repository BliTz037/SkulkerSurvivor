using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpDropper : MonoBehaviour
{
    public GameObject XpPrefab;

    public void DropXp()
    {
        Instantiate(XpPrefab, transform.position, Quaternion.identity);
    }
}
