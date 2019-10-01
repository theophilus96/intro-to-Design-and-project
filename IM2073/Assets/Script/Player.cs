using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour {

	private Rigidbody rb;

	[SerializeField]
	private float speed;
	private float runspeed = 10f;

	private Animator anim;


	float lengthinZaxis = 35f;
	float gapLength = 35f;

	[SerializeField]
	Text scoreUI;

	Vector3 lastposition;

	[SerializeField]
	GameObject platform;

	[SerializeField]
	Transform firstobject;

	float _score = 0f;
	int score = 0;

	public GameObject restartBtn;
	public GameObject exitBtn;
	//public GameObject loseText;

	void Start () {
		anim = GetComponent<Animator> ();
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = new Vector3 (0f, 0f, runspeed);
		lastposition = firstobject.transform.position;
		InvokeRepeating ("Spawning", 0f, 0.7f);
	}

	public class Wave : MonoBehaviour
	{

		void OnTriggerEnter(Collider col)
		{

		}
	}

	private void scoreUpdate()
	{
		_score += (5f * Time.deltaTime);
		score = Mathf.RoundToInt (_score);

		scoreUI.text = score.ToString ();
	}

	private void Spawning()
	{
		GameObject _object = Instantiate (platform) as GameObject;
		int _random = Random.Range (0, 7);
		if (_random <= 4) {
			_object.transform.position = lastposition + new Vector3 (0f, 0f, lengthinZaxis);

		} else {
			_object.transform.position = lastposition + new Vector3 (0f, 0f, 10f);

		}
		lastposition = _object.transform.position;
	}


	// Update is called once per frame
	void Update () {

		if (rb.velocity.z < runspeed) {
			rb.AddForce (new Vector3 (-0.00001f, 0f, 3f));
		}
		if (runspeed != 0) {
			runspeed = runspeed + 0.0001f;
		}
		if (Input.GetButtonDown("Jump")) {

			rb.AddForce (0f, 4f,0f, ForceMode.Impulse);
			anim.SetBool ("isrunning", false);
			anim.Play ("Jumping");
		}
		scoreUpdate();
	}
	//public class wave: MonoBehaviour {
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Water")
		{
			GameOver();


		}


	}
	private void GameOver()
	{
		Debug.Log("Game Over");
		Time.timeScale = 0;
		restartBtn.gameObject.GetComponent<CanvasGroup> ().alpha = 1f;
		exitBtn.gameObject.GetComponent<CanvasGroup> ().alpha = 1f;
		restartBtn.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts = true; //this prevents the UI element to receive input events
		exitBtn.gameObject.GetComponent<CanvasGroup> ().blocksRaycasts =  true; //this prevents the UI element to receive input events

		//loseText.SetActive (true);
		//GameObject.FindGameObjectWithTag("voices").GetComponent<AudioSource>().Stop();
	}
	private void GameWin()
	{
		Debug.Log("You win!");
		Time.timeScale = 0;

	}
	}
	