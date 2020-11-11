using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

/// <summary>
/// 截图保存安卓手机相册
/// </summary>
public class Pict : MonoBehaviour
{
    public Text text;
    string _name = "";

    /// <summary>
    /// 保存截屏图片，并且刷新相册 Android
    /// </summary>
    /// <param name="name">若空就按照时间命名</param>
    public void CaptureScreenshot()
    {
        _name = "";
        _name = "Screenshot_" + GetCurTime() + ".png";


#if UNITY_STANDALONE_WIN      //PC平台
       // 编辑器下
       // string path = Application.persistentDataPath + "/" + _name;       
        string path = Application.dataPath + "/" + _name;
        ScreenCapture.CaptureScreenshot(path, 0);
        Debug.Log("图片保存地址" + path);

#elif UNITY_ANDROID     //安卓平台
        //Android版本
        StartCoroutine(CutImage(_name));
        //在手机上显示路径
        // text.text = "图片保存地址" + Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/DCIM/Camera/" + _name;
        text.text = "图片保存地址" + Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/截屏/" + _name;
#endif
    }
    //截屏并保存
    IEnumerator CutImage(string name)
    {
        //图片大小  
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        yield return new WaitForEndOfFrame();
        tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, true);
        tex.Apply();
        yield return tex;
        byte[] byt = tex.EncodeToPNG();

        string path = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android"));

        //  File.WriteAllBytes(path + "/DCIM/Camera/" + name, byt);   //保存到  安卓手机的  DCIM/下的Camera   文件夹下
        File.WriteAllBytes(path + "/截屏/" + name, byt);         //保存到安卓手机的 文件管理下面的  《截屏》文件夹下      
        string[] paths = new string[1];
        paths[0] = path;
        ScanFile(paths);
    }
    //刷新图片，显示到相册中
    void ScanFile(string[] path)
    {
        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }

    }
    /// <summary>
    /// 获取当前年月日时分秒，如20181001444
    /// </summary>
    /// <returns></returns>
    string GetCurTime()
    {
        return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
            + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
    }

}