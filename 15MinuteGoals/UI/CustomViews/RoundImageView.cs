using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using static Android.Graphics.Bitmap;
using static Android.Graphics.PorterDuff;

namespace _15MinuteGoals.UI.CustomViews
{

    public class RoundedImageView : ImageView
    {
        protected RoundedImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public RoundedImageView(Context context) : base(context)
        {
        }

        public RoundedImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public RoundedImageView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public RoundedImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {

            Drawable drawable = Drawable;

            if (drawable == null)
            {
                return;
            }

            if (Width == 0 || Height == 0)
            {
                return;
            }

            Bitmap b = ((BitmapDrawable)drawable).Bitmap;
            Bitmap bitmap = b.Copy(Bitmap.Config.Argb8888, true);

            int w = Width, h = Height;

            Bitmap roundBitmap = getRoundedCroppedBitmap(bitmap, w);
            Paint paint = new Paint();
            canvas.DrawBitmap(roundBitmap, 0, 0, null);

        }

        public static Bitmap getRoundedCroppedBitmap(Bitmap bitmap, int radius)
        {
            Bitmap finalBitmap;
            if (bitmap.Width != radius || bitmap.Height != radius)
                finalBitmap = CreateScaledBitmap(bitmap, radius, radius,
                        false);
            else
                finalBitmap = bitmap;
            Bitmap output = Bitmap.CreateBitmap(finalBitmap.Width,
                    finalBitmap.Height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(output);

            Paint paint = new Paint();
            Rect rect = new Rect(0, 0, finalBitmap.Width,
                    finalBitmap.Height);
            paint.AntiAlias = true;
            paint.FilterBitmap = true;
            paint.Dither = true;
            canvas.DrawARGB(0, 0, 0, 0);
            paint.Color = Color.ParseColor("#BAB399");
            canvas.DrawCircle(finalBitmap.Width / 2 + 0.7f,
                    finalBitmap.Height / 2 + 0.7f,
                    finalBitmap.Width / 2 + 0.1f, paint);
            paint.SetXfermode(new PorterDuffXfermode(Mode.SrcIn));
            canvas.DrawBitmap(finalBitmap, rect, rect, paint);

            return output;
        }

    }
}