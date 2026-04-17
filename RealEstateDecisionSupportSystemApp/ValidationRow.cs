using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateDecisionSupportSystemApp
{
	public class ValidationRow
	{
		public int Index { get; set; }
		public float RealPrice { get; set; }
		public float PredictedPrice { get; set; }
		public float Error { get; set; }
		public float AbsoluteError { get; set; }

		public float SqFt { get; set; }
		public float Bedrooms { get; set; }
		public float Bathrooms { get; set; }
		public string Brick { get; set; } = "";
		public string Neighborhood { get; set; } = "";
	}
}
