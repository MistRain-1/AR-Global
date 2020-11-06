using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //hit用来存储碰撞物体的信息
            RaycastHit hit;
            //ray表示射线，hit存储物体的信息,1000为设定射线发射的距离
            if (Physics.Raycast(ray, out hit, 1000))
            {

                 if(hit.transform.tag=="Build")
                  {
                    hit.transform.GetComponent<ProjectControl>().ShowInterface();
                  }
            }
        }
    }
    
}
