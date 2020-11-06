using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audios;
    public Slider slider;//音量大小调整条
    public Text text;//音量文本
    public Toggle isSilence;//静音开关

    void Start()
    {
        audios.volume = 0.5f;//设置音量初始值为50
    }

    // Update is called once per frame
    void Update()
    {
        audios.mute = isSilence.isOn;//静音开关
        audios.volume = slider.value / 100;
        text.text = (slider.value).ToString();
    }
}
