using System.Collections;
using UnityEngine;

public class BulletController2 : MonoBehaviour
{
	public GameObject explosionPrefab;
	private new AudioSource audio;

	public AudioClip sound01;
	void Start()
	{
		audio = gameObject.AddComponent<AudioSource>();
	}
	void Update()
	{
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		Vector2 force = new Vector2(-0.05f, 0.0f);
		rb.AddForce(force, ForceMode2D.Impulse);
		//transform.Translate(-0.009f, 0, 0);

	}
	/*void OnTriggerEnter2D(Collider2D coll)
	{
		//GameObject.Find("Canvas").GetComponent<UIController>().AddScore();


		{

			//audio.PlayOneShot(sound01);
			//Destroy(coll.gameObject);
			//Destroy(this.gameObject);

		}
	}*/
}
