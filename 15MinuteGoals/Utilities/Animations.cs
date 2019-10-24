using Android.Animation;
using Android.Views;
using System;
using System.Collections.Generic;

namespace _15MinuteGoals.Utilities
{
    public class Animations
    {
        public void AnimateObject(View view, string[] PropertyNames, float[] Values, long Duration = 150)
        {
            if (PropertyNames != null || PropertyNames.Length != 0)
            {
                List<Animator> animations = new List<Animator>();
                for (int i = 0; i < PropertyNames.Length; i++)
                {
                    ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(view, PropertyNames[i], Values[i]);
                    animations.Add(objectAnimator);
                }

                AnimatorSet animatorSet = new AnimatorSet();
                animatorSet.PlayTogether(animations.ToArray());
                animatorSet.SetDuration(Duration);

                animatorSet.Start();
            }
            else
            {
                throw new ArgumentNullException(nameof(PropertyNames));
            }
        }
        public void AnimateObject(View view, string PropertyName, float Value, long Duration = 150)
        {
            if (PropertyName != null || PropertyName.Length != 0)
            {
                List<Animator> animations = new List<Animator>();
                ObjectAnimator objectAnimator = ObjectAnimator.OfFloat(view, PropertyName, Value);
                animations.Add(objectAnimator);

                AnimatorSet animatorSet = new AnimatorSet();
                animatorSet.PlayTogether(animations.ToArray());
                animatorSet.SetDuration(Duration);

                animatorSet.Start();
            }
            else
            {
                throw new ArgumentNullException(nameof(PropertyName));
            }
        }
    }
}