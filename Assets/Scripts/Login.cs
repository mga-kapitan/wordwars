using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {
	private string source;
	private MySqlConnection conexao;
	private MySqlDataAdapter adapter;
	private string server;
	private string database;
	private string uid;
	private string password;

	void Start () {
		source =       "Server=localhost;" +
			"Database = wordwars;" +    
			"User ID = root;" +
			"Pooling = false;" +
			"Password= ";
		ConectarBanco(source);
		Listar (conexao);

	}

	// Update is called once per frame
	void Update () {

	}

	void ConectarBanco (string _source){
		conexao = new MySqlConnection (_source);
		conexao.Open ();
	}

	void Listar (MySqlConnection _conexao){
		MySqlCommand comando = _conexao.CreateCommand();
		comando.CommandText = "Select * from Account";
		MySqlDataReader dados = comando.ExecuteReader();
		while (dados.Read()){
			string nome = (string)dados["nome"];
			Debug.Log("Usuario " + nome);
		}
	}
}
