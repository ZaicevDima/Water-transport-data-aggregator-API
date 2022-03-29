namespace WaterTransportAPI.Models
{
    /// <summary>
    /// Класс, описывающий погодные условия.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Температура в градусах цельсий.
        /// </summary>
        public double TemperatureC { get; set; }

        /// <summary>
        /// Влажность воздуха.
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        /// Давление в мм. ртутного столба.
        /// </summary>
        public double PressureHg { get; set; }

        /// <summary>
        /// Текстовое описание погоды.
        /// </summary>
        public string Condition { get; set; } = String.Empty;

        /// <summary>
        /// Время восхода солнца.
        /// </summary>
        public string Sunrise { get; set; } = String.Empty;

        /// <summary>
        /// Время захода солнца.
        /// </summary>
        public string Sunset { get; set; } = String.Empty;

        /// <summary>
        /// Прилив.
        /// </summary>
        public string Hightide { get; set; } = String.Empty;

        /// <summary>
        /// Отлив.
        /// </summary>
        public string Lowtide { get; set; } = String.Empty;
    }
}
