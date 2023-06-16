using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource car1Audio;
    [SerializeField] private AudioSource car2Audio;
    [SerializeField] private AudioSource explosionAudio;
    [SerializeField] private AudioSource successAudio;
    [Space]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private float pitchFromCar;
    private float currentSpeed;
    private List<Rigidbody> cars;

    private void Start()
    {
        List<GameObject> carObj = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        cars = new List<Rigidbody>();
        foreach (GameObject obj in carObj)
        {
            cars.Add(obj.GetComponent<Rigidbody>());
        }
    }

    private void Update()
    {
        EngineSound();
    }

    void EngineSound()
    {
        Rigidbody carRb = cars[0];
        currentSpeed = carRb.velocity.magnitude;
        Debug.Log(carRb.velocity.magnitude);
        pitchFromCar = carRb.velocity.magnitude / maxPitch;

        if (currentSpeed < minSpeed)
        {
            car1Audio.pitch = minPitch;
        }

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            car1Audio.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed > maxSpeed)
        {
            car1Audio.pitch = maxPitch;
        }

        carRb = cars[1];
        currentSpeed = carRb.velocity.magnitude;
        pitchFromCar = carRb.velocity.magnitude / maxPitch;

        if (currentSpeed < minSpeed)
        {
            car2Audio.pitch = minPitch;
        }

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            car2Audio.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed > maxSpeed)
        {
            car2Audio.pitch = maxPitch;
        }
    }

    public void PlayExplosionSound()
    {
        explosionAudio.Play();
    }

    public void PlaySuccessSound()
    {
        successAudio.Play();
    }
}
