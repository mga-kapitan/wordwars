using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour {

	public void LogoutLoad (string sl)
	{
		SceneManager.LoadScene(sl);
	}
}
