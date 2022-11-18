using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrustForce = 100f;
    [SerializeField] float rocketRotateDegree = 10f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBoosterParticleEffect;
    [SerializeField] ParticleSystem leftBoosterParticleEffect;
    [SerializeField] ParticleSystem rightBoosterParticleEffect;


    Rigidbody myRigidbody;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * mainThrustForce * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainBoosterParticleEffect.isPlaying)
            {
                mainBoosterParticleEffect.Play();
            }

        }
        else
        {
            audioSource.Stop();
            mainBoosterParticleEffect.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rocketRotateDegree);
            if (!rightBoosterParticleEffect.isPlaying)
            {
                rightBoosterParticleEffect.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))       /*new condition if the first condition is false*/
        {
            ApplyRotation(-rocketRotateDegree);
            if (!leftBoosterParticleEffect.isPlaying)
            {
                leftBoosterParticleEffect.Play();
            }
        }
        else                                           /*if others don't work this one */
        {
            rightBoosterParticleEffect.Stop();
            leftBoosterParticleEffect.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        myRigidbody.freezeRotation = false; // unfreezing rotation so physics system can take over
    }


}
