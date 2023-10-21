using UnityEngine;

public class CreateCube : MonoBehaviour
{
	public GameObject cubePrefab;  // ������ ����

private void OnMouseDown()
	{
		// ������� ��� � ��������� ���������
		GameObject cube = Instantiate(cubePrefab, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
		cube.transform.localScale = new Vector3(1f, 0.1f, 1f);
	}
}