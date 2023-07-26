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
			// TO DO CURRENT		if (((JObject)jObject["data"]).ContainsKey("time"))

			IWeatherCurrentModel targetWeatherModel;
			if (((JObject)jObject["data"]).ContainsKey("values"))
			{
				targetWeatherModel = Factory.CreateWeatherModelTommorowIOCurrent;
			}
			else
			{
				throw new InvalidDataException("Invalid Type property");				// TODO handle bad data error
			};

			// Populate the object properties
			serializer.Populate(jObject.CreateReader(), targetWeatherModel);

			return targetWeatherModel;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
