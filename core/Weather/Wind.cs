class Wind {
    private double speed;
    private double gust;
    private double direction;

    Wind(double speed, double gust, string direction) {
        this.speed = speed;
        this.gust = gust;
        this.direction = direction;
    }

    double getSpeed() {
        return speed;
    }

    double getGust() {
        return gust;
    }

    double getDirection() {
        return direction;
    }

    void setSpeed(double speed) {
        this.speed = speed;
    }

    void setGust(double gust) {
        this.gust = gust;
    }

    void setDirection(string direction) {
        this.direction = direction;
    }
}