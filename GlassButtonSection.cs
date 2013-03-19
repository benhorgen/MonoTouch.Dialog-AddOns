using System;
using System.Drawing;
using MonoTouch.UIKit;

namespace MonoTouch.Dialog.AddOn
{
	public static class GlassButtonExtension
	{
		public static Element CreateGlassButtonElement(GlassButton button)
		{
			UIViewElement imageElement = new UIViewElement(null, button, true);
			imageElement.Flags = UIViewElement.CellFlags.DisableSelection | UIViewElement.CellFlags.Transparent;				
			return imageElement;
		}

		public static GlassButton CreateGlassButton(string buttonLabelText) 
		{ 
			return CreateGlassButton(buttonLabelText, DefaultColor, DefaultButtonWidth, DefaultButtonHeight, null);
		}

		public static GlassButton CreateGlassButton(string buttonLabelText, UIColor color) 
		{ 
			return CreateGlassButton(buttonLabelText, color, DefaultButtonWidth, DefaultButtonHeight, null);
		}

		public static GlassButton CreateGlassButton(string buttonTitle, UIColor color, float width, float height, ButtonClickDelegate touchUpInside)
		{
			GlassButton button = new GlassButton(new RectangleF(0, 0, width, height));
			button.NormalColor = color;
			button.HighlightedColor = UIColor.LightGray;
			button.SetTitleColor(UIColor.FromRGBA(255, 255, 255, 255), UIControlState.Normal);
			button.SetTitleColor(UIColor.FromRGBA(0, 0, 0, 255), UIControlState.Highlighted);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			button.SetTitle(buttonTitle, UIControlState.Normal);
			
			button.TouchUpInside += (s, e) => { if (touchUpInside != null) touchUpInside(s, e); };
			
			return button;
		}
		
		public delegate void ButtonClickDelegate(object sender, EventArgs e);

		public const float DefaultButtonHeight = 44;
		public const float DefaultButtonWidth = 300;
		public static UIColor DefaultColor = UIColor.FromRGB(0, 63, 107);
	}
}

