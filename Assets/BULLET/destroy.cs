using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
	
		/// <summary>
		/// 衝突した時
		/// </summary>
		
		void OnCollisionEnter2D(Collision2D collision)
		{
			//Debug.Log("Hit");
			if (collision.gameObject.tag == "GROUND")
			{
				Destroy(this.gameObject);
			}
		}
}
