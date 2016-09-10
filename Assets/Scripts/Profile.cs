using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour {

	public void ProfileLoad(string sl)
	{
		SceneManager.LoadScene (sl);
	}
}
