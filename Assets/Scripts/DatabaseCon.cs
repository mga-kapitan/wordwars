using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

public class DatabaseCon : MonoBehaviour {

	//public string host = "localhost", database = "wordwar", _name = "root", pass = "";
	public bool pooling = true;

	private string conString;
	private MySqlConnection con = null;
	private MySqlCommand cmd = null;
	private MySqlDataReader dr = null;

	private MD5 _md5Hash;

	void Start ()
	{
		DontDestroyOnLoad (this.gameObject);
		conString = "Server=localhost;Database=wordwars;Uid=root;Pwd=;Pooling=";
		if (pooling) {
			conString += "true;";
		} else {
			conString += "false;";
		}

		try {
			con = new MySqlConnection(conString);
			con.Open();
			Debug.Log(con.State);
		}
		catch(Exception e) {
			Debug.Log (e);
		}
	}

	void OnApplicationQuit () {
		if (con != null) {
			if (con.State.ToString () != "Closed") {
				con.Close ();
				Debug.Log ("Connection Closed");
			}
		}
	}
}
