using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{

    public Transform MinimumBoundary;
    public Transform MaxBoundary;
    public Transform UpBoundary;
    public Transform DownBoundary;

    public float Speed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform currentTransform = transform;

        float horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        currentTransform.Translate(Vector3.right * horizontal);

        // Adds the vertical movement, not necessary
        float vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        currentTransform.Translate(Vector3.up * vertical);

        float x = Mathf.Clamp(currentTransform.position.x,
      MinimumBoundary.position.x,
      MaxBoundary.position.x);
        float y = Mathf.Clamp(currentTransform.position.y, DownBoundary.position.y, UpBoundary.position.y);

        currentTransform.position = new Vector3(x, y, currentTransform.position.z);

        transform.position = currentTransform.position;


    }
}