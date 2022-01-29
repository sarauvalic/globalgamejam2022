using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float forceStrengthMin;
    public float forceStrengthMax;
    public float velocityThreshold;

    public Transform forcePos;

    public UnityEvent OnBottleSpin;
    public UnityEvent OnBottleStop;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.angularVelocity.z <= velocityThreshold)
	    {
            rigidbody.angularVelocity= Vector3.zero;
            OnBottleStop.Invoke();
	    }
    }

    public void SpinBottle()
	{
        var forceStrength = Random.Range(forceStrengthMin, forceStrengthMax);
        rigidbody.AddForceAtPosition(forcePos.right * - forceStrength, forcePos.position, ForceMode.Impulse);
        OnBottleSpin.Invoke();
	}
}
