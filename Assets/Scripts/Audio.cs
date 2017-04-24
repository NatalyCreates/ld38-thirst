using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    public static Audio Instance;

    public AudioClip winTune, jump;

	void Awake ()
    {
        Instance = this;
        Cursor.visible = false;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayWinTune()
    {
        GetComponent<AudioSource>().PlayOneShot(winTune, 1f);
    }

    public void PlayJumpSound()
    {
        GetComponent<AudioSource>().PlayOneShot(jump, 1f);
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
