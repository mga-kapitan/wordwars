using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Login : MonoBehaviour {

	private MySqlConnection connection = new MySqlConnection();
	private MySqlCommand cmd;
	private MySqlDataReader mdr;
	string query;
	string user, pass;
	GameObject userGo, passGo;
	InputField userCo, passCo;


	public void LoginSceneLoad (string scene)
	{
		connection.ConnectionString = "Server=localhost;Database=wordwars;Uid=root;Pwd=;Pooling=";
		userGo = GameObject.Find ("inputUsername");
		userCo = userGo.GetComponent<InputField> ();
		user = userCo.text;
		passGo = GameObject.Find ("inputPassword");
		passCo = passGo.GetComponent<InputField> ();
		pass = passCo.text;

		Debug.Log (user);
		Debug.Log (pass);

		try
		{
			connection.Open();

			query = "select * from account where Usrnm = '" + user + "' and Psswrd = '" + pass + "'";
			cmd = new MySqlCommand(query, connection);
			mdr = cmd.ExecuteReader();

			int count = 0;

			while (mdr.Read())
			{
				count++;

				if (count == 1)
				{
					SceneManager.LoadScene(scene);
				}
			}

			if (count != 1)
			{
			//	EditorUtility.DisplayDialog("","Incorrect username or password.","Ok");
			}

		}catch (Exception q)
		{
			Debug.Log (q);
		}
		finally
		{
			connection.Close();
		}
	}

	public void RegisterLoad (string scene)
	{
		SceneManager.LoadScene (scene);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit ();
		}
	}
}
