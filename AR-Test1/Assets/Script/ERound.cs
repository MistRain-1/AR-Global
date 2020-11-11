using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

/*使用者：谁需要2指放大缩小，该脚本挂载到该物体上
 * 功能：
 * 手指放到物体上通过手指的姿态放大或者缩小物体,
 * 离开恢复原始大小
 * 触碰屏幕模型依据y轴旋转
 */
public class ERound : MonoBehaviour
{

    public float ff;
    // Subscribe to events
    void OnEnable()
    {
        EasyTouch.On_TouchStart2Fingers += On_TouchStart2Fingers;
        EasyTouch.On_Pinch += OnPinch;
        EasyTouch.On_PinchEnd += On_PinchEnd;
        EasyTouch.On_Swipe += On_Swipe;
    }

    void OnDisable()
    {
        UnsubscribeEvent();
    }

    void OnDestroy()
    {
        UnsubscribeEvent();
    }

    // Unsubscribe to events
    void UnsubscribeEvent()
    {
        EasyTouch.On_TouchStart2Fingers -= On_TouchStart2Fingers;
        EasyTouch.On_Pinch -= OnPinch;
        EasyTouch.On_PinchEnd -= On_PinchEnd;
        EasyTouch.On_Swipe -= On_Swipe;
    }

    void Start()
    {
        ff = transform.localScale.x;
    }


    private void On_TouchStart2Fingers(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            EasyTouch.SetEnableTwist(false);
            EasyTouch.SetEnablePinch(true);
        }
    }

    private void OnPinch(Gesture gesture)
    {
        if (gesture.pickedObject == gameObject)
        {
            transform.localScale += Vector3.one * gesture.deltaPinch * 0.01f;
            float t = transform.localScale.x;
            t = Mathf.Clamp(t, ff * 0.3f, ff * 3f);
            transform.localScale = Vector3.one * t;
        }
    }
    private void On_PinchEnd(Gesture gesture)
    {

        if (gesture.pickedObject == gameObject)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            EasyTouch.SetEnableTwist(true);
        }
    }
    private void On_Swipe(Gesture gesture)
    {
        this.transform.localEulerAngles -= Vector3.up * gesture.deltaPosition.x;
    }
}