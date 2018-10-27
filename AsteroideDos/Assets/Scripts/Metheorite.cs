using UnityEngine;
using System.Collections;

public class Metheorite : MonoBehaviour {

  private int Life = 5;
    private int[] special;
    public GameObject player;
    Ship pS;


  public Transform ExplosionParticleSystem;

	// Use this for initialization
	void Start () {

        special = new int[3];
        special[1] = 0;
        special[2] = 1;
        special[3] = 2;

        player = GameObject.FindGameObjectWithTag("Player");
        pS = player.GetComponent<Ship>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Bullet") {
      TakeDamage(other.gameObject, 1);

    }else if (other.gameObject.tag == "BulletRoja")
        {
            TakeDamage(other.gameObject, 2);
        }
  }

  void TakeDamage(GameObject bullet, int quita) {
    Destroy(bullet);
    Life--;
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {

            pS.UpdateScore(100);
            Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject); 


    }
  }

  void ResetColor() {
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }


}
