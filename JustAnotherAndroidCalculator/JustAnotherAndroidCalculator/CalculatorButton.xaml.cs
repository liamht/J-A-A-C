using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JustAnotherAndroidCalculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorButton : Button
	{
		public CalculatorButton ()
		{
			InitializeComponent();
		}
	}
}