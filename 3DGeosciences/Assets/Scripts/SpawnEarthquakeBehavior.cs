using UnityEngine;
using System.Collections;

public class SpawnEarthquakeBehavior : StateMachineBehaviour {
	public string exitTrigger;
	public GameObject prefab;
	private GameObject go;
	private bool spawned = false;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		go = (GameObject)Instantiate (prefab, Vector3.zero, Quaternion.identity);
		go.transform.SetParent(animator.gameObject.transform);
		spawned = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (MoveObjectOnSphere() && Input.GetMouseButtonDown(0)) {
			spawned = true;
			animator.SetTrigger(exitTrigger);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(spawned == false){
			Destroy(go);
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	private bool MoveObjectOnSphere(){
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			//if(hit.collider.transform.name.Equals("Earth")){
				go.transform.position = hit.point;
				//go.transform.Rotate(Vector3.right * 90f);
				go.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
			//}
			return true;
		}
		return false;
	}
}
