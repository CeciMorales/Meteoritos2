using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

  public bool damage = false;

  public Transform SpawnBulletPosition;

  public Transform Bullet;

    public Transform BulletRoja;

  public GameObject ShipMesh;

    public int Life = 100;

    public int SScore;

    public bool changedWeapon;

	// Use this for initialization
	void Start () {
        changedWeapon = false;
	
	}

    void OnGUI()
    {
        GUILayout.Label("Life= " + Life);
        GUILayout.Label("Score= " + SScore);

    }

    // Update is called once per frame
    void LateUpdate () {
    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) {
      Shoot();
    }

    if (Input.GetKeyDown(KeyCode.C))
        {
            changedWeapon = true;
        }
	}

  void Shoot() {

    if (changedWeapon == false)
    {
            
            Instantiate(Bullet, SpawnBulletPosition.position, Quaternion.identity);

    }else if (changedWeapon == true)
        {
            
            Instantiate(BulletRoja, SpawnBulletPosition.position, Quaternion.identity);
        }
    
  }

    public void UpdateScore(int score)
    {
        SScore += score;
    }

    void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Metheorite") {
      Damaged();
            Life -= 5;

    }else if (other.gameObject.tag == "BulletNaranja")
        {
            Damaged();

        }
  }

  void Damaged() {
    if (damage) {
      return;
    }
    damage = true;
    ShipMesh.GetComponent<Renderer>().material.color = Color.red;
    Invoke("NotDamaged", 2);
  }

  void NotDamaged() {
    damage = false;
    ShipMesh.GetComponent<Renderer>().material.color = Color.white;
  }
}
