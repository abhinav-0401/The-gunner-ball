using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource EffectsSource;
	public AudioSource MusicSource;
    public AudioClip Themesong;
    private void Awake() {
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
    private void Start() {
        MusicManager.instance.PlayMusic(Themesong);
    }

    public void Play(AudioClip clip){
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }
    public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
        MusicSource.loop = true;
		MusicSource.Play();
	}
}
