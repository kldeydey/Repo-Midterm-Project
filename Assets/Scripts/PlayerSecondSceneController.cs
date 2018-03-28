using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSecondSceneController : MonoBehaviour {

	public float		speed = 3.0f;
	public float		jumpSpeed = 2.0f;
	public float		distanceGround = 0.5f;
	public Text			winText;
	public Text			countText;

	public Scene		scene;
	private	int 		count = 0;
	private Rigidbody	rb;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		scene = SceneManager.GetActiveScene ();
		winText.text = "";
		countText.text = "Count: 0";
	}

	void FixedUpdate ()
	{
		if (Input.GetKey("escape"))
			SceneManager.LoadScene ("Menu");
		

		if (Input.GetKey (KeyCode.Space))
		{
			Vector3 jumpVelocity = new Vector3(0, jumpSpeed, 0);
			rb.velocity += jumpVelocity;
		}


		if (!(isGrounded ()) && (transform.position.y < -10))
			endGame ("WASTED !");
			
		float horizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
		rb.MovePosition (transform.position + movement);

	}

	bool isGrounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, distanceGround);
	}

	void OnTriggerEnter(Collider item)
	{

		if (item.gameObject.CompareTag ("lastCoin")) {
			endGame ("WIN :)");
			item.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString();
		}
		 if (item.gameObject.CompareTag ("Coins"))
		{
			item.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString();
		}
	}

	void OnCollisionEnter(Collision item)
	{
		if (item.gameObject.CompareTag ("Boxes")){
			endGame ("WASTED !");
		}
	}



	void endGame(string str)
	{
		winText.text = str;
		speed = 0;
		StartCoroutine ("waitSeconds");

	}

	IEnumerator waitSeconds(){
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Menu");
	}
}
