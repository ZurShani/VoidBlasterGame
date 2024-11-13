using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("General setup settings")]
    [SerializeField] float throwForce = 30f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 12f;
    
    [Header("Laser gun array")]
    [SerializeField] GameObject[] lasers;
    
    [Header("Player input tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    
    [Header("Screen position based on tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;
    
    float xThrow, yThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * throwForce;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos  = Mathf.Clamp(rawXPos, -xRange, xRange);
        
        float yOffset = yThrow * Time.deltaTime * throwForce;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos  = Mathf.Clamp(rawYPos, -1.191251f, yRange);
        
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
    
}
