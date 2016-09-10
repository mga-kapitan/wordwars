using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

	public void MainMenuLoad(string sl)
	{
		SceneManager.LoadScene (sl);
	}
}
