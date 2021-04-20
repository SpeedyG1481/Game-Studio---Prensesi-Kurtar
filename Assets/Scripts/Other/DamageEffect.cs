using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.5F);
    }
    
}
