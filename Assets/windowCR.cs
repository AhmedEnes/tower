using UnityEngine;

 class windowCR : MonoBehaviour
{
	private windowCR windowCrComponent;
	// ������ ����, ������� ����� �����������
	public GameObject cubePrefab;
	public Vector3 rotation = new Vector3(-83.045f, -84.341f, 46.596f);  // ��������


	private void Start()
{
    // �������� ��������� windowCR �������� �������
    windowCrComponent = GetComponent<windowCR>();
}
	private void Update()
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