using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class CharacterController : MonoBehaviour
    {
        public Animator anim;
        public bool isDead;

        public virtual void PlayAnimation(string animationName)
        {
            anim.Play(animationName);
        }
    }
}

