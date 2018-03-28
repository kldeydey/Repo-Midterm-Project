using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public	Transform	player;
	public	float		smoothSpeed = 0.125f;
	public	Vector3		offset;

	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 newPosition = player.position;
		newPosition.y = newPosition.y - 1;

		Vector3 desiredPosition = newPosition + offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothPosition;
	}
}
