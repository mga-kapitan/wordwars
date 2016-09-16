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

public class UserReg : MonoBehaviour {

	private MySqlConnection connection = new MySqlConnection();
	private MySqlCommand cmd;
	private MySqlDataReader mdr;
	string query;
	string user, dispname, pass, conPass;
	GameObject userGo, passGo, userDispGo, conPassGo;
	InputField userCo, passCo, userDispCo, conPassCo;

	public void userSubmit (string scene)
	{
		connection.ConnectionString = "Server=localhost;Database=wordwars;Uid=root;Pwd=;Pooling=";
		userGo = GameObject.Find ("regUser");
		userCo = userGo.GetComponent<InputField> ();
		user = userCo.text;

		userDispGo = GameObject.Find ("regDispName");
		userDispCo = userDispGo.GetComponent<InputField> ();
		dispname = userDispCo.text;


		passGo = GameObject.Find ("regPass");
		passCo = passGo.GetComponent<InputField> ();
		pass = passCo.text;

		conPassGo = GameObject.Find ("regPass");
		conPassCo = conPassGo.GetComponent<InputField> ();
		conPass = conPassCo.text;

		Debug.Log (user);
		Debug.Log (pass);
			try
			{
				connection.Open();
				if (pass == conPass)
				{
					query = "INSERT INTO account (Usrnm, Psswrd, dispname) VALUES ('"+user+"','"+pass+"','"+dispname+"')";
					cmd = new MySqlCommand (query, connection);
					cmd.ExecuteNonQuery();
					Debug.Log("Registered Succesfully!");
					SceneManager.LoadScene("CharSelect");
			}else{
				Debug.Log("Invalid Input");
			}
			}
			catch (Exception q)
			{
				Debug.Log (q);
			}
			finally
			{
				connection.Close();
			}
		}
}
