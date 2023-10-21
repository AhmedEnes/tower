using UnityEngine;
using UnityEngine.UI;

public class butshow : MonoBehaviour
{
	public Button button;

	private void Start()
	{
		// Получаем компонент Button, который будет появляться/скрываться
		button = GetComponent<Button>();

		// Скрываем кнопку при старте
		button.interactable = false;
	}

	private void Update()
	{
		// Проверяем, было ли нажатие на объект в текущем кадре
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
			{
				// Если объект был нажат, делаем кнопку видимой
				button.interactable = true;
			}
			else
			{
				// Если объект не был нажат, скрываем кнопку
				button.interactable = false;
			}
		}
	}
}