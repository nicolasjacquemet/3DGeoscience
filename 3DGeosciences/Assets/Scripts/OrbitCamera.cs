using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

	public float _distance = 2f;
	public float _sensitivity = 10f;

	float _currentRotationRight = 0f;
	float _currentRotationUp = 0f; 

	//public float _x = 0f;
	//public float _y = 0f;
	
	void Start(){
		Rotate (_currentRotationRight, _currentRotationUp);
	}


	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			_currentRotationRight += Input.GetAxis("Mouse Y") * _sensitivity;
			_currentRotationUp += Input.GetAxis("Mouse X") * _sensitivity;
		}
		Rotate (_currentRotationRight, _currentRotationUp);
	}

	void Rotate(float degreesAroundRight, float degreesAroundUp){
		Quaternion rotation = Quaternion.Euler (-degreesAroundRight, degreesAroundUp, 0f);
		transform.rotation = rotation;
		Vector3 percheASelfie = new Vector3(0f, 0f, -_distance);
		transform.position = rotation * percheASelfie;
		
	}
}
