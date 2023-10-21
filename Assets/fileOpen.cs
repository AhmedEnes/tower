using UnityEngine;
using System.IO;

public class CubeClick : MonoBehaviour
{
	private void OnMouseDown()
	{
		// Путь к файлу, который вы хотите считать
		string filePath = "C:\\Users\\ahmed\\Downloads\\MWS_Заявка на сертификат.docx";

		// Считывание текстового файла
		string content = File.ReadAllText(filePath);

		// Вывод содержимого файла в консоль
		Debug.Log(content);
	}
}