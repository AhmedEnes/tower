using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crobj : MonoBehaviour
{

	public Vector3 rotation = new Vector3(-83.045f, -84.341f, 46.596f);  // ��������
	private crobj windowCrComponent;
	public GameObject cubePrefab;
	// Start is called before the first frame update
	void Start()
    {
		windowCrComponent = GetComponent<crobj>();
	}

    // Update is called once per frame
    void Update()
    {
	
	}

	void OnMouseDown()
	{
		if (windowCrComponent == null)
		{
			Debug.LogError("windowCR component is missing!");
			return;
		}

		// ���� ���������� ����, ���������� ��� �� ��������� �����������
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// ���������, ���� �� ������������ ���� � ������������
			if (Physics.Raycast(ray, out hit))
			{

				// ������� ��� � ������������� ��� ������� � �������
				GameObject cube = Instantiate(windowCrComponent.cubePrefab, hit.point, Quaternion.Euler(windowCrComponent.rotation));
				cube.transform.localScale = new Vector3(1f, 0.1f, 1f);
				cube.GetComponent<Renderer>().material.color = Color.gray;

				cube.name = "Cube_" + Time.time;
			}
		}
	}
}
