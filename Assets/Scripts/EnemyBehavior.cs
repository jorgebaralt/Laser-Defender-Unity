using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public float ShotsPerSeconds = 0.5f;

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage();
			if(health <= 0){
				Destroy (gameObject);
			}
		}
	}
	void Update(){
	float probability = ShotsPerSeconds * Time.deltaTime;
	if(Random.value<probability)
		Shoot();
	}
	void Shoot(){
		GameObject missile = Instantiate(projectile,transform.position + new Vector3(0f,-1f,0f),Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector3(0f,-(projectileSpeed),0f);
	}
}
