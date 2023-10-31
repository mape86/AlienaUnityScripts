using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private Material _material;
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    public AudioClip _clip;
    public PlayerEnergyLevel _playerEnergyLevel;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.tag != "ActivatedSphere")
        {
            _material.SetColor("_EmissionColor", Color.green * 2);
            _particleSystem.startColor = Color.green;
            _particleSystem.emissionRate = 100;

            _playerEnergyLevel.GainEnergy(20);

            gameObject.tag = "ActivatedSphere";

            _audioSource.PlayOneShot(_clip);

        }
    }
}
