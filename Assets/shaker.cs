using UnityEngine;
using System.Collections;

public class shaker : MonoBehaviour {

    private Vector3 start;
    private float stepSize
    {
        get { return speed / Vector3.Distance(start, target); }
    }
    private bool ascending = true;

    public Vector3 target = new Vector3(0, 0, 0);
    public float speed = 1;
    public float progress = 0;

	// Use this for initialization
	void Start () {
        start = this.transform.position;
        if (progress != 0)
            this.transform.position = Vector3.Lerp(start, target, progress);
	}
	
	// Update is called once per frame
	void Update () {
        if (progress > 1)
            ascending = false;
        else if (progress < 0)
            ascending = true;

        if (ascending)
            progress += stepSize * Time.deltaTime;
        else
            progress -= stepSize * Time.deltaTime;

        this.transform.position = Vector3.Lerp(start, target, progress);

	}
}
