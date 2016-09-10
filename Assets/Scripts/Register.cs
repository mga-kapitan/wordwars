using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour {

	public void RegisterLoad (string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
