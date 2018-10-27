using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
  void OnBecameInvisible() {
    Destroy(gameObject);
  }
}
