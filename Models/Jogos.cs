namespace eplay.Models.eplay
{
	public class Jogos
	{
			public int? id { get; set; }
			public string? name { get; set; }
			public string? description { get; set; }
			public string? release_date { get; set; }
			public Prices? prices { get; set; }
			public Details? details { get; set; }
			public Media? media { get; set; }
	

		public class Prices
		{
			public int? discount { get; set; }
			public float? old { get; set; }
			public float? current { get; set; }
		}

		public class Details
		{
			public string? category { get; set; }
			public string? system { get; set; }
			public string? developer { get; set; }
			public string? publisher { get; set; }
			public string[]? languages { get; set; }
		}

		public class Media
		{
			public string? thumbnail { get; set; }
			public string? cover { get; set; }
			public Gallery[]? gallery { get; set; }
		}

		public class Gallery
		{
			public string? type { get; set; }
			public string? url { get; set; }
		}
	}
}
