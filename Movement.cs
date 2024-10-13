using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineparticles;
    [SerializeField] ParticleSystem leftthrusterparticles;
    [SerializeField] ParticleSystem rightthrusterparticles;

    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            StartThrusting();
        }

        else
        {
            StopThrusting();
        }

    }

        void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }

    }


    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineparticles.isPlaying)
        {
            mainEngineparticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainEngineparticles.Stop();
    }

        private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightthrusterparticles.isPlaying)
        {
            rightthrusterparticles.Play();
        }
    }

        private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftthrusterparticles.isPlaying)
        {
            leftthrusterparticles.Play();
        }
    }
    
    private void StopRotating()
    {
        rightthrusterparticles.Stop();
        leftthrusterparticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over.
    }
}
