using UnityEngine;

public class GunAnimatorController : MonoBehaviour
{
    bool walking;
    bool shot;
    Animator animator;
    public ParticleSystem fireParticle;
    private void Start()
    {
        this.walking = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Walking", false);
    }

    public void SetWalking(bool walking)
    {
        this.walking = walking;
    }

    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        fireParticle.Stop();
        fireParticle.Play();
    }

    private void Update()
    {
        animator.SetBool("Walking", walking);
    }

}
