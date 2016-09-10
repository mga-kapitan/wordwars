using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour {

//	private GameObject theButton;
	private ColorBlock theColor;
	bool isMute;

	void Start ()
	{
		//theButton = GameObject.Find ("btnSound");
	}

	public void Mute ()
	{
		isMute = !isMute;
			AudioListener.volume =  isMute ? 0 : 1;
	}
}
