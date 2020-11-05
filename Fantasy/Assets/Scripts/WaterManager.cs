using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{

    private Collider water;

    // Start is called before the first frame update
    void Start()
    {
        water = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider water)
    {
        if (water.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
