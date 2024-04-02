using StarterAssets;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (starterAssetsInputs.aim)
        {
            animator.SetBool("Aiming", true);
        }
        else
        {
            animator.SetBool("Aiming", false);
        }

        if (starterAssetsInputs.move != Vector2.zero && starterAssetsInputs.aim)
        {
            animator.SetBool("AimWalking", true);
        }
        else
        {
            animator.SetBool("AimWalking", false);
        }

        if (starterAssetsInputs.move == Vector2.zero && starterAssetsInputs.aim)
        {
            animator.SetBool("IdleAiming", true);
        }
        else
        {
            animator.SetBool("IdleAiming", false);
        }
    }
}
