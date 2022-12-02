using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpCollecter : MonoBehaviour
{
    private XpManager _xpManager;

    public void Awake()
    {
        _xpManager = GetComponent<XpManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Xp")
        {
            var xp = other.gameObject.GetComponent<Xp>();
            
            _xpManager.AddXp(xp.XpValue);
            Destroy(other.gameObject);
        }
    }
}
