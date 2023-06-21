using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApiApp.Model.WeatherModels;

namespace WeatherApiApp.Services.Converters
{
	internal class JsonIWeatherCurrentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(IWeatherCurrentModel).IsAssignableFrom(objectType);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jObject = JObject.Load(reader);

			// Choose the concrete type based on the 'Type' property
			IWeatherCurrentModel target = jObject["data"].ToString() switch                           // TO DO CURRENT
			{
				"values" => Factory.CreateWeatherModelTommorowIOCurrent,
				
				_ => throw new InvalidDataException("Invalid Type property"),
			};

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), target);

			return target;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
