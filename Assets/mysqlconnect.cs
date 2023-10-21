using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseConnection : MonoBehaviour
{
	private string connectionString;
	private MySqlConnection connection;

	private void Start()
	{
		
	}

	private void OnDestroy()
	{
		// Закройте подключение к базе данных при завершении работы скрипта
		if (connection != null && connection.State == ConnectionState.Open)
		{
			connection.Close();
			Debug.Log("Подключение к базе данных MySQL закрыто");
		}
	}
	private void OnMouseDown()
	{

		// Задайте параметры подключения к вашей базе данных MySQL
		string connectionString = "server=31.41.63.47;user=root;database=rahmo;port=6782;password=iipru2020;";

		// Создайте подключение к базе данных

		// Подключитесь к базе данных
		try
		{
			MySqlConnection connection = new MySqlConnection(connectionString);
			connection.Open();
			Debug.Log("Подключение к базе данных MySQL успешно установлено");
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;

			int value = UnityEngine.Random.Range(0, 99999);
			float xCoordinate = position.x;
			float yCoordinate = position.y;
			float zCoordinate = position.z;
			float xRotation = rotation.x;
			float yRotation = rotation.y;
			float zRotation = rotation.z;
			float wRotation = rotation.w;
			string query = "INSERT INTO `Piramida_window`(`window_number`, `coor-X`, `coor-Y`, `coor-Z`, `rot-X`, `rot-Y`, `rot-Z`, `rot-W`) VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
			MySqlCommand command = new MySqlCommand(query, connection);
			command.Parameters.AddWithValue("@window_number", value);
			command.Parameters.AddWithValue("@coor-X", xCoordinate);
			command.Parameters.AddWithValue("@coor-Y", yCoordinate);
			command.Parameters.AddWithValue("@coor-Z", zCoordinate);
			command.Parameters.AddWithValue("@rot-X", xRotation);
			command.Parameters.AddWithValue("@rot-Y", yRotation);
			command.Parameters.AddWithValue("@rot-Z", zRotation);
			command.Parameters.AddWithValue("@rot-W", wRotation);
			command.ExecuteNonQuery();
			Debug.Log("Запись успешно добавлена в базу данных");

			connection.Close(); // закрытие соединения с базой данных
		}
		catch (MySqlException ex)
		{
			Debug.Log("Ошибка подключения к базе данных MySQL: " + ex.Message);
		}
	}


		public void AddValueToDatabase(string value)
	{
		// Создайте SQL-запрос для добавления значения в таблицу
		string query = "INSERT INTO murcaworlds(murcaworld) VALUES (@value)";

		// Создайте команду для выполнения запроса
		MySqlCommand command = new MySqlCommand(query, connection);

		// Задайте параметры для запроса
		command.Parameters.AddWithValue("@value", "авы");

		// Выполните запрос к базе данных
		try
		{
			command.ExecuteNonQuery();
			Debug.Log("Новое значение успешно добавлено в базу данных");
		}
		catch (MySqlException ex)
		{
			Debug.Log("Ошибка при добавлении значения в базу данных: " + ex.Message);
		}
	}
}