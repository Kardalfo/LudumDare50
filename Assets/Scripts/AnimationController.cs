using System;
using System.Collections;
using System.Collections.Generic;
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
