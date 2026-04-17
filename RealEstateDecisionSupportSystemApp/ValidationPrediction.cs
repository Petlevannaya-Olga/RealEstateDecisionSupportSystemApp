using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateDecisionSupportSystemApp
{
	public class ValidationPrediction
	{
		public int Index { get; set; }
		public float RealPrice { get; set; }

		public float SqFt { get; set; }
		public float Bedrooms { get; set; }
		public float Bathrooms { get; set; }

		public string Brick { get; set; } = "";
		public string Neighborhood { get; set; } = "";

		[ColumnName("Score")]
		public float Score { get; set; }
	}
}
