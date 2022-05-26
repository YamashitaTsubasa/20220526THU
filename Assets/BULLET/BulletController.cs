using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
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
		Vector2 force = new Vector2(0.05f, 0.0f);
		rb.AddForce(force, ForceMode2D.Impulse);
		//transform.Translate(0.009f, 0, 0);
		
		
	}
	/*void OnCollisionEnter(Collision coll)
	{
		//GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

		{
			if (coll.gameObject.tag == "WALL")
			{

				Destroy(gameObject);
			}
			//audio.PlayOneShot(sound01);
			//Destroy(coll.gameObject);
			//Destroy(this.gameObject);

		}
	}*/
}