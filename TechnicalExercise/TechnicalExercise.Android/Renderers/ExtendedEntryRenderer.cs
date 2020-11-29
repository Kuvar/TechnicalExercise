using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using System;
using TechnicalExercise;
using TechnicalExercise.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace TechnicalExercise.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
	{

        public ExtendedEntryRenderer(Context context):base(context)
        {

        }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control == null || e.NewElement == null) return;

			UpdateBorders();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null) return;

            if(e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
			    UpdateBorders();
		}

		void UpdateBorders()
		{
            GradientDrawable shape = new GradientDrawable();
			var view = (ExtendedEntry)this.Element;
			shape.SetShape(ShapeType.Rectangle);
			shape.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));
			Control.SetPadding(
					(int)DpToPixels(this.Context, Convert.ToSingle(12)),
					Control.PaddingTop,
					(int)DpToPixels(this.Context, Convert.ToSingle(12)),
					Control.PaddingBottom);


			if (view.IsBorderErrorVisible){
                shape.SetStroke(3, view.BorderErrorColor.ToAndroid());
			}
            else{
                shape.SetStroke(3, Android.Graphics.Color.LightGray);
				this.Control.SetBackground(shape);
            }
			
            this.Control.SetBackground(shape);
		}

		public static float DpToPixels(Context context, float valueInDp)
		{
			DisplayMetrics metrics = context.Resources.DisplayMetrics;
			return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
		}
	}
}