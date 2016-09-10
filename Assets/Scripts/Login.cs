using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {

	public void SceneLoad (string scene)
	{
		SceneManager.LoadScene(scene);
	}
}
