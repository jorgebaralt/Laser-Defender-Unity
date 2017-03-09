using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15f;
	public float padding = 1f;
	float xmin,xmax;
	public GameObject projectile;
	public float projectileSpeed;
	public float shootingRate;
	public float health = 250f;
	public AudioClip ShootSound;
	
	void Die(){
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
		Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	void Shoot(){
			AudioSource.PlayClipAtPoint(ShootSound,transform.position);
			GameObject beam = Instantiate(projectile,transform.position + new Vector3(0f, 1f,0f),Quaternion.identity) as GameObject;
			beam.rigidbody2D.velocity = new Vector3(0f,projectileSpeed,0f);
			

	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
		InvokeRepeating("Shoot", 0.00001f,shootingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
		CancelInvoke("Shoot");
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey (KeyCode.A))
		{
			this.transform.position += Vector3.left *speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey (KeyCode.D))
		{
			this.transform.position += Vector3.right *speed * Time.deltaTime;
		}
		float newX = Mathf.Clamp(transform.position.x,xmin,xmax);
		transform.position = new Vector3(newX,transform.position.y,transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.getDamage();
			if(health <= 0){
				Destroy (gameObject);
				Die ();
			}
		}
	}
}
