using UnityEngine;

 class windowCR : MonoBehaviour
{
	private windowCR windowCrComponent;
	// Префаб куба, который будет создаваться
	public GameObject cubePrefab;
	public Vector3 rotation = new Vector3(-83.045f, -84.341f, 46.596f);  // значения


	private void Start()
{
    // Получаем компонент windowCR текущего объекта
    windowCrComponent = GetComponent<windowCR>();
}
	private void Update()
	{
		if (windowCrComponent == null)
		{
			Debug.LogError("windowCR component is missing!");
			return;
		}

		// Если происходит клик, отображаем куб на выбранной поверхности
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// Проверяем, есть ли столкновение луча с поверхностью
			if (Physics.Raycast(ray, out hit))
			{
				// Создаем куб и устанавливаем его позицию и размеры
				GameObject cube = Instantiate(windowCrComponent.cubePrefab, hit.point, Quaternion.Euler(windowCrComponent.rotation));
				cube.transform.localScale = new Vector3(1f, 0.1f, 1f);
				cube.GetComponent<Renderer>().material.color = Color.gray;

				cube.name = "Cube_" + Time.time;
			}
		}
	}
}