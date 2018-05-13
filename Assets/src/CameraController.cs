using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	Vector3 offset;

	void Start() {
		offset = transform.position - player.transform.position;
	}

	void FixedUpdate() {
		transform.position = player.transform.position + offset;
	}
}
