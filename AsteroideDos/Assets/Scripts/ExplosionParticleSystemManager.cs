using UnityEngine;
using System.Collections;

public class ExplosionParticleSystemManager : MonoBehaviour {

  public ParticleSystem TheParticleSystem;

	// Update is called once per frame
	void Update () {
    if (!TheParticleSystem.IsAlive()) {
      Destroy(gameObject);
    }
	}
}
