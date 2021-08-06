using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")] [SerializeField] float xRange = 10f;
    [Tooltip("In m/s")] [SerializeField] float ySpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //float yThrow = CrossPlatformInputManager.GetAxis("vertical");

        float xOffset = xRange * xThrow * Time.deltaTime;
        float xRaw = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(xRaw, -xRange, xRange);
        //yOffset += ySpeed * yThrow * Time.deltaTime;

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }
}