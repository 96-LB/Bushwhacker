using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foo : MonoBehaviour
{

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("created!");
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab)
        {
            Debug.Log(prefab.name);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
