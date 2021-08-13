using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	[Tooltip("In m/s")] [SerializeField] float xRange = 7f;
	[Tooltip("In m/s")] [SerializeField] float yRange = 5f;
	[SerializeField] float positionPitchFactor = -4.5f;
	[SerializeField] float rotationPitchFactor = -10f;
	[SerializeField] float rotationRollFactor = -6f;
	[SerializeField] float rotationYawFactor = 5f;
	float xThrow, yThrow;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ProcessTranslation();
		ProcessRotation();
	}

	private void ProcessRotation()
	{
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToThrow = yThrow * rotationPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToThrow;
		float yaw = xThrow * rotationYawFactor;
		float roll = xThrow * rotationRollFactor;
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xRange * xThrow * Time.deltaTime;
		float xRaw = transform.localPosition.x + xOffset;
		float clampedXPos = Mathf.Clamp(xRaw, -xRange, xRange);

		float yOffset = yRange * yThrow * Time.deltaTime;
		float yRaw = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp(yRaw, -yRange, yRange);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}
}