using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audi;
    void Start()
    {
        audi = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AudioStart()
    {
        audi.Play();
    }
    public void AudioStop()
    {
        audi.Stop();
    }
}
