using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float sizeOfWave = 3;
    public float waveSpeed = 1;
    public float waveIntensity = 1;

    private Transform[] children;
    private float canvasHeight;
    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++) {
            children[i] = transform.GetChild(i);
        }

        canvasHeight = Camera.main.orthographicSize*2;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > Mathf.PI * waveSpeed * 2) {
            timePassed -= Mathf.PI * waveSpeed * 2;
        }

        for (int i = 0; i <children.Length; i++) {
            Transform child = children[i];
            float y = Mathf.Sin(timePassed * waveSpeed) * waveIntensity /*+ timePassed / 2 * waveSpeed*/ - i*sizeOfWave;
            if (y < -canvasHeight) {

            }
            child.localPosition = new Vector3(child.localPosition.x, y, child.localPosition.z);
        }
    }
}
