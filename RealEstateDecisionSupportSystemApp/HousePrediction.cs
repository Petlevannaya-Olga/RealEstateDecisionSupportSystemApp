using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateDecisionSupportSystemApp
{
	public class HousePrediction
	{
		[ColumnName("Score")]
		public float PredictedPrice { get; set; }
	}
}
