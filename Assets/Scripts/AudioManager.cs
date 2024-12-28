using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    public AudioSource _audioSource;
    public AudioClip _hit,_reload,_shoot,_lose,win;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
   

    

    
}
