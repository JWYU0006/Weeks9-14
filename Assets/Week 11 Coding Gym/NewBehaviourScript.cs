using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    public float speed = 2;
    AudioSource audioSource;
    public List<AudioClip> audioClipsList;
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        sr.flipX = (direction < 0);
        animator.SetFloat("Speed", Mathf.Abs(direction));
        transform.position += transform.right * direction * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            particleSystem.Play(!particleSystem.isPlaying);
        }
    }

    public void FootStepSound()
    {
        int whichClip = Random.Range(0, 2);
        audioSource.clip = audioClipsList[whichClip];
        audioSource.PlayOneShot(audioSource.clip);
        Debug.Log(audioSource.clip.name + "Audio played" + whichClip);
    }
}
