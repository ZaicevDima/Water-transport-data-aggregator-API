class Pressure {
    double pressureMM;
    double pressurePascal;

    Pressure(double pressureMM = null, double pressurePascal = null) {
        this.pressureMM = pressureMM;
        this.pressurePascal = pressurePascal;
    }

    setValueMM(double value) {
        this.pressureMM = value;
    }

    setValuePascal(double value) {
        this.pressurePascal = value;
    }

    double getValueInMM() {
        return pressureMM;
    }

    double getValuePascal() {
        return pressurePascal;
    }
}