class Temperature {
    private double value;
    private UnitOfTemperature unitOfTemperature;

    Temperature(double value, UnitOfTemperature unitOfTemperature) {
        this.value = value;
        this.unitOfTemperature = unitOfTemperature;
    }

    Temperature(double value, string unitOfTemperature) {
        this.value = value;
        string unitOfTemperature = unitOfTemperature.ToUpper();
        switch(unitOfTemperature) {
            case "KELVIN":
                this.unitOfTemperature = UnitOfTemperature.KELVIN;
                break;
            case "CELSIUS":
                this.unitOfTemperature = UnitOfTemperature.CELSIUS;
                break;
            case "FAHRENHEIT":
                this.unitOfTemperature = UnitOfTemperature.FAHRENHEIT;
        }
    }

    setValue(double value, UnitOfTemperature unitOfTemperature) {
        this.value = value;
        this.unitOfTemperature = unitOfTemperature;
    }

    double getValue(UnitOfTemperature unitOfTemperature = UnitOfTemperature.CELSIUS) {
        switch (unitOfTemperature) {
            case UnitOfTemperature.KELVIN:
                return toKelvin();
                break;
            case UnitOfTemperature.CELSIUS:
                return toCelsius;
                break;
            case UnitOfTemperature.FAHRENHEIT:
                return toFarengeight();
                break;
        }
    }

    UnitOfTemperature getUnitOfTemperature(UnitOfTemperature unitOfTemperature) {
        return unitOfTemperature;
    }

    private double toKelvin() {
        switch (unitOfTemperature) {
            case UnitOfTemperature.KELVIN:
                return value;
                break;
            case UnitOfTemperature.CELSIUS:
                return value + 273.15;
                break;
            case UnitOfTemperature.FAHRENHEIT:
                return 5 * (value - 32) / 9 + 273.15;
                break;
        }
    }
    
    private double toCelsius() {
        switch (unitOfTemperature) {
            case UnitOfTemperature.KELVIN:
                return value - 273.15;
                break;
            case UnitOfTemperature.CELSIUS:
                return value;
                break;
            case UnitOfTemperature.FAHRENHEIT:
                return 5 * (value - 32) / 9;
                break; 
        }
    }

    private double toFarengeight() {
        switch (unitOfTemperature) {
            case UnitOfTemperature.KELVIN:
                return 9 * (value - 273.15) / 5 + 32;
                break;
            case UnitOfTemperature.CELSIUS:
                return 9 * value / 5 + 32;
                break;
            case UnitOfTemperature.FAHRENHEIT:
                return value;
                break;
        }
    }
}