using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150f;

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log(collider);
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage();
			if(health <= 0){
				Destroy (gameObject);
			}
			Debug.Log ("hit by projectlile");
		}
	}
}
