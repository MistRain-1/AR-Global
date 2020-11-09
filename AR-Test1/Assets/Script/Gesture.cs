using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;
public class Gesture : MonoBehaviour
{

    WebCamTexture texture;
    public GameObject canvas;
    public Text text;
    public void OnBtnCamera()
    {
        StartCoroutine(GetTexture());
    }
    public IEnumerator GetTexture()
    {

        // 在截屏之前先把所有的UI无效化，这样截屏的图片就不会含有UI了
        canvas.GetComponentInChildren<Canvas>().enabled = false;

        // 等这一帧渲染结束，这样截屏时图片才不会失真或者变色
        yield return new WaitForEndOfFrame();

        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);

        screenShot.ReadPixels(rect, 0, 0, false);
        screenShot.Apply();

        byte[] bytes = screenShot.EncodeToPNG();
        Debug.Log("1");
        
        //string screenShotName = "Maballo_ss_" + System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png";
        //File.WriteAllBytes(Application.persistentDataPath + "/" + screenShotName, screenShot.EncodeToPNG());

        
        string destination = "/sdcard/DCIM/Camera";
        //判断目录是否存在，不存在则会创建目录
        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }
        string path = destination + "/" +"LuXun"+ System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png";
        //存图片
        System.IO.File.WriteAllBytes(path, screenShot.EncodeToPNG());

        Debug.Log("2");

        //string fileName = "Assets/UnityChanAR/" + Time.time + ".png";
        //System.IO.File.WriteAllBytes(fileName, bytes);
        text.text= Application.persistentDataPath + " / " + path;
        // 在截屏之后记得把所有的UI重新有效化，这样就不会影响App运行了
        canvas.GetComponentInChildren<Canvas>().enabled = true;
    }
}
