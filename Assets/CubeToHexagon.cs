using UnityEngine;

public class HexahedronGenerator : MonoBehaviour
{
	void Start()
	{
		GenerateHexahedron();
	}

	void GenerateHexahedron()
	{
		Mesh hexahedronMesh = new Mesh();

		Vector3[] vertices = new Vector3[]
		{
			new Vector3(0, 0, 0),    // A
            new Vector3(1, 0, 0),    // B
            new Vector3(1, 0, 1),    // C
            new Vector3(0, 0, 1),    // D
            new Vector3(0, 1, 0),    // E
            new Vector3(1, 1, 0),    // F
            new Vector3(1, 1, 1),    // G
            new Vector3(0, 1, 1)     // H
        };

		int[] triangles = new int[]
		{
			0, 2, 1,    // A-C-B
            0, 3, 2,    // A-D-C
            0, 4, 7,    // A-E-H
            0, 7, 3,    // A-H-D
            0, 1, 5,    // A-B-F
            0, 5, 4,    // A-F-E
            6, 5, 1,    // G-F-B
            6, 1, 2,    // G-B-C
            6, 2, 3,    // G-C-D
            6, 3, 7,    // G-D-H
            6, 7, 4,    // G-H-E
            6, 4, 5     // G-E-F
        };

		hexahedronMesh.vertices = vertices;
		hexahedronMesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = hexahedronMesh;
	}
}