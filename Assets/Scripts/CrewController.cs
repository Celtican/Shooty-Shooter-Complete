using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewController : MonoBehaviour
{
    public Sprite[] randomSpriteList;

    private float timeOffset;
    private float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        timeOffset = Random.Range(0, 1000f);
        timeScale = Random.Range(8f, 12f);

        GetComponent<SpriteRenderer>().sprite = randomSpriteList[Random.Range(0, randomSpriteList.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Sin(Time.time*timeScale + timeOffset) *30);
    }
}
