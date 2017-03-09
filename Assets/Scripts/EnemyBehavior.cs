using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject projectile;
	public float health = 150f;
	public float projectileSpeed = 10f;
	public float ShotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	public AudioClip ShootSound;
	public AudioClip DeathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage();
			if(health <= 0){
				Destroy (gameObject);
				scoreKeeper.Score(1);
				AudioSource.PlayClipAtPoint(DeathSound,transform.position);
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
		AudioSource.PlayClipAtPoint(ShootSound,transform.position);
	}
}
