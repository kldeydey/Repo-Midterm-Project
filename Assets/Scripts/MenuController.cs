using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	
	public void buttonOneClicked()
	{
		SceneManager.LoadScene ("Scene2", LoadSceneMode.Single);
	}
	public void buttonExitClicked()
	{
		Application.Quit ();
	}
}
