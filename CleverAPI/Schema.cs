using System.Collections.Generic;

namespace CleverAPI
{
	public class Result
	{
		public IEnumerable<Section> Data { get; set; }

		public class Section
		{
			public Data data { get; set; }

			public class Data
			{
				public IEnumerable<string> Students { get; set; }
			}
		}
	}
}
