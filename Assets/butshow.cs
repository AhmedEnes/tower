using UnityEngine;
using UnityEngine.UI;

public class butshow : MonoBehaviour
{
	public Button button;

	private void Start()
	{
		// �������� ��������� Button, ������� ����� ����������/����������
		button = GetComponent<Button>();

		// �������� ������ ��� ������
		button.interactable = false;
	}

	private void Update()
	{
		// ���������, ���� �� ������� �� ������ � ������� �����
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
			{
				// ���� ������ ��� �����, ������ ������ �������
				button.interactable = true;
			}
			else
			{
				// ���� ������ �� ��� �����, �������� ������
				button.interactable = false;
			}
		}
	}
}