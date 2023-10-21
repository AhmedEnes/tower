using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	float _speed = 0.02f;
	float _rotationSpeed = 10;
	private Vector2 _rotation;
	int _maxYAngle = 80;
	void Update()
	{
		if (Input.anyKey)
		{
			if (Input.GetKey(KeyCode.W))
			{
				transform.position += transform.forward * _speed;
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position -= transform.forward * _speed;
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += transform.right * _speed;
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.position -= transform.right * _speed;
			}
			if (Input.GetKey(KeyCode.LeftControl))
			{
				transform.position += Vector3.down * _speed;
			}
			if (Input.GetKey(KeyCode.Space))
			{
				transform.position += Vector3.up * _speed;
			}
		}
		_rotation.x += Input.GetAxis("Mouse X") * _rotationSpeed;
		_rotation.y -= Input.GetAxis("Mouse Y") * _rotationSpeed;
		_rotation.x = Mathf.Repeat(_rotation.x, 360);
		_rotation.y = Mathf.Clamp(_rotation.y, -_maxYAngle, _maxYAngle);
		transform.rotation = Quaternion.Euler(_rotation.y, _rotation.x, 0);
	}
}