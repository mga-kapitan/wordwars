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
	//Database Config VariablesM
	private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=wordwars;Uid=root;Pwd=;Pooling=");
	private MySqlCommand cmd;
	string query;
	public 

	static string user, dispname, pass, conPass;
	GameObject userGo, passGo, userDispGo, conPassGo;
	InputField userCo, passCo, userDispCo, conPassCo;

	public void userSubmit (string scene)
	{
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

	/*
		 *  Boolean Avatar Selection
		 * 1 = Male Avatar
		 * 2 = Female Avatar
		 */

	public void BoySelect(string scene){
		Debug.Log ("Male char selected");

	}
	public void GirlSelect(string scene){
		Debug.Log ("Female Char Selected");
	}
	/*
	 * 		try{
			connection.Open ();
			query = "UPDATE account SET avatar=1 where Usrnm='"+user+"'";
			cmd = new MySqlCommand(query,connection);
			cmd.ExecuteNonQuery();
			Debug.Log(query);
		}catch(Exception q){
			Debug.Log (q);
		}finally{
			connection.Close ();
		}
	*/
}
