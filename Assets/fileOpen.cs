using UnityEngine;
using System.IO;

public class CubeClick : MonoBehaviour
{
	private void OnMouseDown()
	{
		// ���� � �����, ������� �� ������ �������
		string filePath = "C:\\Users\\ahmed\\Downloads\\MWS_������ �� ����������.docx";

		// ���������� ���������� �����
		string content = File.ReadAllText(filePath);

		// ����� ����������� ����� � �������
		Debug.Log(content);
	}
}