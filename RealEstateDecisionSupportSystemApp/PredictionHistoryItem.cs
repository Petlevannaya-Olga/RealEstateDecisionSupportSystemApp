using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDecisionSupportSystemApp
{
	public class PredictionHistoryItem
	{
		public DateTime CreatedAt { get; set; }

		public float SqFt { get; set; }
		public float Bedrooms { get; set; }
		public float Bathrooms { get; set; }
		public string Brick { get; set; } = "";
		public string Neighborhood { get; set; } = "";

		public float ActualPrice { get; set; }
		public float PredictedPrice { get; set; }
		public float Difference { get; set; }

		public string Decision { get; set; } = "";
	}
}
