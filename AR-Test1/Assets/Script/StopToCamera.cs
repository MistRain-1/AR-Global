using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Global;
    public GameObject Camera;
    public GameObject Target;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CatchGlobal()
    {
        Global.transform.SetParent(Camera.transform);
    }
    public void NoCatchGlobal()
    {
        Global.transform.SetParent(Target.transform);
    }
}
