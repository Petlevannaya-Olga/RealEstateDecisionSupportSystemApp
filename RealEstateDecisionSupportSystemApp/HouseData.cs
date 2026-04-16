using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateDecisionSupportSystemApp
{
	public class HouseData
	{
		public float Price { get; set; }
		public float SqFt { get; set; }
		public float Bedrooms { get; set; }
		public float Bathrooms { get; set; }
		public string Brick { get; set; } = string.Empty;
		public string Neighborhood { get; set; } = string.Empty;
	}
}
