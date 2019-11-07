using Android.Animation;
using Android.Views;
using System;
using System.Collections.Generic;

namespace _15MinuteGoals.Utilities
{
    public class Animations
    {
        public AnimatorSet animatorSet = new AnimatorSet();
        public delegate void AnimationEventHandler();
        public static event AnimationEventHandler AnimationEnded;
        public void AnimateObject(View view, string[] PropertyNames, float[] Values, long Duration = 150, long Delay = 0)
        {
            if (PropertyNames != null || PropertyNames.Length != 0)
            {
                List<Animator> animations = new List<Animator>();
                for (int i = 0; i < PropertyNames.Length; i++)
                {
                    ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(view, PropertyNames[i], Values[i]);
                    animations.Add(objectAnimator);
                }
                ObjectAnimator lastAnimation = (ObjectAnimator)animations[animations.Count - 1];
                lastAnimation.AddListener(new AnimationListner());

                animatorSet.PlayTogether(animations.ToArray());
                animatorSet.SetDuration(Duration);
                animatorSet.StartDelay = Delay;

                animatorSet.Start();
            }
            else
            {
                throw new ArgumentNullException(nameof(PropertyNames));
            }
        }
        public void AnimateObject(View view, string PropertyName, float Value, long Duration = 150, long Delay = 0)
        {
            if (PropertyName != null || PropertyName.Length != 0)
            {
                List<Animator> animations = new List<Animator>();
                ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(view, PropertyName, Value);
                animations.Add(objectAnimator);
                ObjectAnimator lastAnimation = (ObjectAnimator)animations[animations.Count - 1];
                lastAnimation.AddListener(new AnimationListner());

                animatorSet.PlayTogether(animations.ToArray());
                animatorSet.SetDuration(Duration);
                animatorSet.StartDelay = Delay;

                animatorSet.Start();
            }
            else
            {
                throw new ArgumentNullException(nameof(PropertyName));
            }
        }

        private class AnimationListner : Java.Lang.Object, Animator.IAnimatorListener
        {
            public void OnAnimationCancel(Animator animation)
            {
                
            }

            public void OnAnimationEnd(Animator animation)
            {
                //AnimationEnded();
            }

            public void OnAnimationRepeat(Animator animation)
            {
                
            }

            public void OnAnimationStart(Animator animation)
            {
                
            }
        }
    }
}