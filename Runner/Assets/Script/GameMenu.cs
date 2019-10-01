using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour {
	public Button resumeBtn;
	public Button restartBtn;
	public Button exitBtn;
	//public GameObject loseText;



	// Use this for initialization
	void Start () {
		//resumeBtn.onClick.AddListener(resumeFunc);
		restartBtn.onClick.AddListener(restartFunc);
		exitBtn.onClick.AddListener(exitFunc);

		//restartBtn.gameObject.SetActive(false);
		restartBtn.gameObject.GetComponent<CanvasGroup> ().alpha = 0f;
		exitBtn.gameObject.GetComponent<CanvasGroup> ().alpha = 0f;
		restartBtn.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = false; //this prevents the UI element to receive input events
		exitBtn.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts =  false; //this prevents the UI element to receive input events

		//		resumeBtn.gameObject.SetActive(false);
		//exitBtn.gameObject.SetActive(false);

		//loseText.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Cancel"))
		{
			Time.timeScale = 0;
			//		resumeBtn.gameObject.SetActive(true);
			restartBtn.gameObject.SetActive(true);
			exitBtn.gameObject.SetActive(true);
		}
	}

	public void resumeFunc()
	{
		Time.timeScale = 1;
		restartBtn.gameObject.SetActive(false);
		//		resumeBtn.gameObject.SetActive(false);
		exitBtn.gameObject.SetActive(false);
	}

	public void restartFunc()
	{
		SceneManager.LoadScene(1);
		Time.timeScale = 1;
	}

	public void exitFunc()
	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1;
		//Application.Quit ();
	}
}
