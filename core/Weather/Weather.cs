class Weather {
    double latitude;
    double longitude;
    Temperature temperature;
    double humidity;
    Wind wind;
    Pressure pressure;
    string condition;
    string sunrise;
    string sunset;
    string hightide;
    string lowtide;

    Weather() {
    }

    Weather buildLatitude(double latitude) {
        this.latitude = latitude;
        return this;
    }

    
    Weather buildLongitude(double longitude) {
        this.longitude = longitude;
        return this;
    }

    
    Weather buildTemperature(double temperature, UnitOfTemperature unitOfTemperature = UnitOfTemperature.CELSIUS) {
        this.temperature = new Temperature(temperature, unitOfTemperature);
        return this;
    }

    
    Weather buildHumidity(double humidity) {
        this.humidity = humidity;
        return this;
    }

    
    Weather buildWind(double speed, double gust, double direction) {
        this.wind = new Wind(speed, gust, direction);
        return this;
    }

    
    Weather buildPressure(double pressureMM, double pressurePascal) {
        this.pressure = new Pressure(pressureMM, pressurePascal);
        return this;
    }

    
    Weather buildCondition(string condition) {
        this.condition = condition;
        return this;
    }
    Weather buildSunrise(string sunrise) {
        this.sunrise = sunrise;
        return this;
    }
    Weather buildSunset(string sunset) {
        this.sunset = sunset;
        return this;
    }
    Weather buildHightide(string hightide) {
        this.hightide = hightide;
        return this;
    }
    Weather buildLowtide(string lowtide) {
        this.lowtide = lowtide;
        return this;
    }
}