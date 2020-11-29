using Xamarin.Forms;

namespace TechnicalExercise
{
	public class ExtendedEntry : Entry
	{
		public static readonly BindableProperty IsBorderErrorVisibleProperty =
			BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(ExtendedEntry), false, BindingMode.TwoWay);

		public bool IsBorderErrorVisible
		{
			get { return (bool)GetValue(IsBorderErrorVisibleProperty); }
			set
			{
				SetValue(IsBorderErrorVisibleProperty, value);
			}
		}

		public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(ExtendedEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderErrorColor
		{
			get { return (Xamarin.Forms.Color)GetValue(BorderErrorColorProperty); }
			set
			{
				SetValue(BorderErrorColorProperty, value);
			}
		}

		public static readonly BindableProperty ErrorTextProperty =
	    BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ExtendedEntry), string.Empty);

		public string ErrorText
		{
			get { return (string)GetValue(ErrorTextProperty); }
			set
			{
				SetValue(ErrorTextProperty, value);
			}
		}

		public static readonly BindableProperty CornerRadiusProperty = 
			BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(ExtendedEntry), Device.OnPlatform<double>(6, 7, 7), BindingMode.TwoWay);
		// Gets or sets CornerRadius value  
		public double CornerRadius
		{
			get => (double)GetValue(CornerRadiusProperty);
			set => SetValue(CornerRadiusProperty, value);
		}
	}
}