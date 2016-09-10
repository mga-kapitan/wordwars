using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	public void SettingsLoad (string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
