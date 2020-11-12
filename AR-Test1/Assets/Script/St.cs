using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
    void Start()
    {
        transform.SetParent(Camera.transform);
        transform.position = Camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
