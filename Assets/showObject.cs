using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class showObject : MonoBehaviour
{
	public GameObject originalObject;

	async void Start()
	{
		try
		{
			string connectionString = "server=31.41.63.47;user=root;database=rahmo;port=6782;password=iipru2020;";
			MySqlConnection connection = new MySqlConnection(connectionString);
			await connection.OpenAsync();
			Debug.Log("Подключение к базе данных MySQL успешно установлено");

			string query = "SELECT `coor-X`, `coor-Y`, `coor-Z`, `rot-X`, `rot-Y`, `rot-Z`, `rot-W` FROM `Piramida_window`";
			MySqlCommand command = new MySqlCommand(query, connection);
			using (MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync())
			{
				List<GameObject> objects = new List<GameObject>();

				while (await reader.ReadAsync())
				{
					float x;
					float.TryParse(reader.GetString(0), out x);

					float y;
					float.TryParse(reader.GetString(1), out y);

					float z;
					float.TryParse(reader.GetString(2), out z);

					float rotationX;
					float.TryParse(reader.GetString(3), out rotationX);

					float rotationY;
					float.TryParse(reader.GetString(4), out rotationY);

					float rotationZ;
					float.TryParse(reader.GetString(5), out rotationZ);

					float rotationW;
					float.TryParse(reader.GetString(6), out rotationW);

					GameObject newObj = Instantiate(originalObject, new Vector3(x, y, z), new Quaternion(rotationX, rotationY, rotationZ, rotationW));
					objects.Add(newObj);

					Debug.Log("Позиция и поворот успешно применены к объекту");
				}

				for (int i = 0; i < objects.Count; i++)
				{
					Vector3 newPosition = new Vector3(objects[i].transform.position.x + (i * 2), objects[i].transform.position.y, objects[i].transform.position.z);

					objects[i].transform.position = newPosition;
				}
			}

			connection.Close();
		}
		catch (MySqlException ex)
		{
			// Обработка ошибок
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}