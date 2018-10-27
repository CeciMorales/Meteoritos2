using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMala : MonoBehaviour {

    public float Speed;
    public float stoppingDistance;
    public float startingDistance;
    private Transform target; //player

    public GameObject BulletEmissor;
    public GameObject Bala;
    private int Life = 10;

    private bool damage = false;

    public GameObject ShipMesh;




    public GameObject ExplosionParticleSystem;

    // Use this for initialization
    void Start () {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("Shoot", 0, 3);

    }

    // Update is called once per frame
    void Update () {

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance && Vector2.Distance(transform.position, target.position) < startingDistance)
        {
            //(from, to)
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

        }

       

    }

    void Shoot()
    {
        Instantiate(Bala, BulletEmissor.transform.position, Quaternion.identity);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject, 1);

        }
        else if (other.gameObject.tag == "BulletRoja")
        {
            TakeDamage(other.gameObject, 2);
        }
    }

    void TakeDamage(GameObject bullet, int quita)
    {
        Destroy(bullet);
        Life--;

        CancelInvoke("ResetColor");
        Invoke("ResetColor", 1);
        if (Life <= 0)
        {
            Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Damaged()
    {
        if (damage)
        {
            return;
        }
        damage = true;
        ShipMesh.GetComponent<Renderer>().material.color = Color.red;
        Invoke("NotDamaged", 2);
    }

    void NotDamaged()
    {
        damage = false;
        ShipMesh.GetComponent<Renderer>().material.color = Color.white;
    }
}
