using UnityEngine;

public class CubeToHexagon : MonoBehaviour
{
	public float edgeLength = 1f;

	void Start()
	{
		// Создаем массив вершин для шестигранника
		Vector3[] vertices = new Vector3[6];
		vertices[0] = new Vector3(0, 0, edgeLength);
		vertices[1] = new Vector3(edgeLength, 0, 0);
		vertices[2] = new Vector3(0, 0, -edgeLength);
		vertices[3] = new Vector3(-edgeLength, 0, 0);
		vertices[4] = new Vector3(0, -edgeLength, 0);
		vertices[5] = new Vector3(0, edgeLength, 0);

		// Создаем массив треугольников для шестигранника
		int[] triangles = new int[24];
		triangles[0] = 0;
		triangles[1] = 5;
		triangles[2] = 4;
		triangles[3] = 0;
		triangles[4] = 1;
		triangles[5] = 5;
		triangles[6] = 1;
		triangles[7] = 3;
		triangles[8] = 5;
		triangles[9] = 3;
		triangles[10] = 4;
		triangles[11] = 5;
		triangles[12] = 1;
		triangles[13] = 0;
		triangles[14] = 2;
		triangles[15] = 1;
		triangles[16] = 2;
		triangles[17] = 3;
		triangles[18] = 2;
		triangles[19] = 4;
		triangles[20] = 3;
		triangles[21] = 2;
		triangles[22] = 0;
		triangles[23] = 4;

		// Создаем меш и добавляем компонент меша к игровому объекту
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		GetComponent<MeshFilter>().mesh = mesh;

		// Поворачиваем грани шестигранника
		transform.eulerAngles = new Vector3(0, 30, -30);
	}
}