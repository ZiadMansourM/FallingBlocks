using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;

    float visibleHeightThreshold;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.down * speed * Time.deltaTime, Space.Self);
        if (transform.position.y < visibleHeightThreshold) {
			Destroy(gameObject); // Can we do this easily on openGL
		}
    }
}
