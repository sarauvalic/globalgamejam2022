using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleController : MonoBehaviour
{
    public Rigidbody rb;
    public float forceStrengthMin;
    public float forceStrengthMax;
    public float velocityThreshold;

    public Transform forcePos;

    public UnityEvent OnBottleSpin;
    public UnityEvent OnBottleStop;

    private bool spinning=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning && rb.angularVelocity.z <= velocityThreshold)
	    {
            Debug.Log("stopped spinning");
            spinning = false;
            //rb.angularVelocity= Vector3.zero;
            rb.angularVelocity.Set(0,0,0);
            OnBottleStop.Invoke();
	    }
    }

    public void SpinBottle()
	{
        var forceStrength = Random.Range(forceStrengthMin, forceStrengthMax);
        rb.AddForceAtPosition(forcePos.right * - forceStrength, forcePos.position, ForceMode.Impulse);
        OnBottleSpin.Invoke();
        StartCoroutine(Wait());
	}
    private IEnumerator Wait()
	{
        yield return new WaitForSeconds(1);
        spinning = true;
	}
}
