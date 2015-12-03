using UnityEngine;
using System.Collections;

public class RaycastSpawner : MonoBehaviour {

	public GameObject prefab;
	private float lastMouseButtonDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown (0)){
			lastMouseButtonDown = Time.time;
		}

		if(Input.GetMouseButtonUp(0) && Time.time - lastMouseButtonDown < 0.1f){
			SpawnOnHit ();
		}


	}

	void SpawnOnHit(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if(hit.collider.transform.name.Equals("Earth")){
				Debug.Log (hit.point);

				//GameObject go = (GameObject)Instantiate (prefab, hit.point, Quaternion.LookRotation(Vector3.zero, hit.normal));
				//go.transform.Rotate(Vector3.right * 90f);
				GameObject go = (GameObject)Instantiate (prefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

				go.transform.SetParent(this.transform);
			}
		}
	}
}
