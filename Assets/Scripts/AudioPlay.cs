using UnityEngine;
using System.Collections;

public class AudioPlay : MonoBehaviour {

	private static AudioPlay instance = null;

	public static AudioPlay Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}