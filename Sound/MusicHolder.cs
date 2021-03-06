﻿using UnityEngine;
using System.Collections;

public class MusicHolder : MonoBehaviour {
	public int[] MusicInStage;
	
	public AudioClip[] allClip;
	
	public float musicTimeOut;
	
	public AudioSource musicPlayer;
	
	public int curStage;
	
	int curMusic;
	
	int[] MusicBefore;
	
	// Use this for initialization
	void Awake () {
		musicPlayer = GetComponent<AudioSource> ();
		MusicBefore = new int[MusicInStage.Length];
		int tempMusic = 0;
		for (int i = 0; i < MusicBefore.Length; i++) {
			MusicBefore[i] = MusicInStage[i] + tempMusic;
			tempMusic += MusicInStage[i];
			//Debug.Log(MusicBefore[i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (!musicPlayer.isPlaying) {
			StartSong();
		}
		if (curStage != PVPGameRule.instance.curStage) {
			NextStage();
		}
	}
	
	public void StartSong(){
		if (curStage == 0) {
			curMusic = (int)UnityEngine.Random.Range (0, MusicBefore [curStage]);
		}
		else {
			curMusic = (int)UnityEngine.Random.Range (MusicBefore [curStage - 1], MusicBefore [curStage]);
		}
		//if(curMusic>allClip.Length&&curMusic >= MusicBefore[curStage+1]-1) curMusic = MusicBefore[curStage] - 1;
		musicPlayer.clip = allClip [curMusic];
		musicPlayer.PlayDelayed (musicTimeOut);

	}
	
	public void NextStage(){
		if (curStage < MusicInStage.Length - 1) {
				curStage++;
				curMusic = MusicBefore[curStage] - 1;
			//Debug.Log (curMusic);
				musicPlayer.Stop ();
				
		}
	}
}
