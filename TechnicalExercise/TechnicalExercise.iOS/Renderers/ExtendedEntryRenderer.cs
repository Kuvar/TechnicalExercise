using CoreGraphics;
using System;
using TechnicalExercise;
using TechnicalExercise.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace TechnicalExercise.iOS
{
	public class ExtendedEntryRenderer : EntryRenderer
	{
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (Control == null || this.Element == null) return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName){
				var view = (ExtendedEntry)this.Element;
				Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
				Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));

				if (view.IsBorderErrorVisible)
				{
					Control.Layer.BorderColor = view.BorderErrorColor.ToCGColor();
					Control.Layer.BorderWidth = new nfloat(0.8);
					Control.Layer.CornerRadius = 5;
				}
				else
				{
					Control.Layer.BorderColor = UIColor.LightGray.CGColor;
					Control.Layer.CornerRadius = 5;
					Control.Layer.BorderWidth = new nfloat(0.8);
				}
            }
		}
	}
}