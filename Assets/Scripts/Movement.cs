using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction _thrust;
    [SerializeField] private float _thrustStrenght = 1000f;
    [SerializeField] private InputAction _rotation;
    [SerializeField] private float _rotationStrenght = 100f;
    [SerializeField] private AudioClip _mainEngineSFX;
    [SerializeField] private ParticleSystem _mainEngineParticles;
    [SerializeField] private ParticleSystem _leftThrustParticles;
    [SerializeField] private ParticleSystem _rightThustParticles;


    private Rigidbody _rb;
    private AudioSource _audioSource;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _thrust.Enable();
        _rotation.Enable();
    }


    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (_thrust.IsPressed())
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        _rb.AddRelativeForce(Vector3.up * _thrustStrenght * Time.fixedDeltaTime);
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_mainEngineSFX);
        }
        if (!_mainEngineParticles.isPlaying)
        {
            _mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        _audioSource.Stop();
        _mainEngineParticles.Stop();
    }

    private void ProcessRotation()
    {
        float rotationInput = _rotation.ReadValue<float>();
        if (rotationInput != 0)
        {
            StartRotation(rotationInput);
        }
        else
        {
            StopRotation();
        }

    }

    private void StartRotation(float rotationInput)
    {
        if (rotationInput < 0)
        {
            StartParticles(_rightThustParticles, _leftThrustParticles);
        }
        else if (rotationInput > 0)
        {
            StartParticles(_leftThrustParticles, _rightThustParticles);
        }

        _rb.freezeRotation = true;
        transform.Rotate(_rotationStrenght * rotationInput * Time.fixedDeltaTime * Vector3.back);
        _rb.freezeRotation = false;
    }

    private void StartParticles(ParticleSystem activate, ParticleSystem deactivate)
    {
        if (!activate.isPlaying)
        {
            deactivate.Stop();
            activate.Play();
        }
    }

    private void StopRotation()
    {
        _leftThrustParticles.Stop();
        _rightThustParticles.Stop();
    }
}
