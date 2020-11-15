using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphereMagic : MonoBehaviour
{

    public GameObject spherePrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSphere();
    }

    public void SpawnSphere()
    {
        Instantiate(spherePrefab, transform.position, Quaternion.identity);
    }
    
}
