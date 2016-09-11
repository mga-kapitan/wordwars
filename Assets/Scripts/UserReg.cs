using UnityEngine;
using UnityEditor;
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
	string user, pass, conPass;
	GameObject userGo, passGo, conPassGo;
	InputField userCo, passCo, conPassCo;

	public void userSubmit (string scene)
	{
		connection.ConnectionString = "Server=localhost;Database=wordwars;Uid=root;Pwd=;Pooling=";
		userGo = GameObject.Find ("regUser");
		userCo = userGo.GetComponent<InputField> ();
		user = userCo.text;
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
				query = "INSERT INTO account (Usrnm, Psswrd) VALUES ('"+userCo.text+"','"+passCo.text+"')";
				cmd = new MySqlCommand (query, connection);
				cmd.ExecuteNonQuery();
				Debug.Log("Registered Succesfully!");
				SceneManager.LoadScene(scene);
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
