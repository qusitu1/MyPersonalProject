using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip footstepClip;
    public float footstepVolume = 0.2f;
    public float minMoveSpeed = 0.1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float moveSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        if (moveSpeed > minMoveSpeed && !audioSource.isPlaying)
        {
            audioSource.volume = footstepVolume;
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
