using UnityEngine;


public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animation animation;
    [SerializeField] private string animationName;


    public void StartAnimation()
    {
        animation.Play(animationName);
    }
}
