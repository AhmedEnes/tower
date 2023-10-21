using UnityEngine;

public class Trapezoid : MonoBehaviour
{
	public float sideLength = 1f; // ����� ������� ��������������
	public float depth = 1f; // ������� ��������������
	public float height = 31f; // 

	private MeshFilter meshFilter;

	private void Awake()
	{
		meshFilter = GetComponent<MeshFilter>();
	}

	private void Start()
	{
		GenerateHexagon();
	}

	private void GenerateHexagon()
	{
		// ������� ����� ���
		Mesh mesh = new Mesh();

	
// ����������� ������ ������
float height = 22f;

		// ������� �������
		Vector3[] vertices = new Vector3[7];
		vertices[0] = new Vector3(sideLength / 2, 0f, depth / 2);
		vertices[1] = new Vector3(sideLength / 2, 0f, -depth / 2);
		vertices[2] = new Vector3(0f, 0f, -depth);
		vertices[3] = new Vector3(-sideLength / 2, 0f, -depth / 2);
		vertices[4] = new Vector3(-sideLength / 2, 0f, depth / 2);
		vertices[5] = new Vector3(0f, 0f, depth);
		vertices[6] = new Vector3(-sideLength, height, 0f);

		// ������� ������������ �� ������
		int[] triangles = new int[18]
		{
	1, 5, 0, // �������� �����
    1, 2, 5,
	2, 3, 5, // ������ �����
    3, 4, 5,
	4, 0, 5, // ������ �����
    4, 6, 0
		};

		// ������� ��� ���������
		Vector3[] normals = new Vector3[7]
		{
	-Vector3.forward,
	-Vector3.forward,
	-Vector3.forward,
	-Vector3.forward,
	-Vector3.forward,
	-Vector3.forward,
	Vector3.up
		};

		// ��������� ������ �� ���
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;

		meshFilter.mesh = mesh;
	}
}