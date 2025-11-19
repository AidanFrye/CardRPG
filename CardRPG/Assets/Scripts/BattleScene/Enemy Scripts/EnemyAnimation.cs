using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    private AnimatorOverrideController overrideController;

    public void SetupAnimations(Enemy enemy)
    {
        enemy.SetAnimator(animator);
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        overrideController["Idle"] = enemy.GetIdleClip();
        overrideController["Attack"] = enemy.GetAttackClip();

        animator.runtimeAnimatorController = overrideController;
        PlayIdle();
    }

    public void PlayIdle() => animator.Play("Idle");
    public void PlayAttack() => animator.Play("Attack");
}