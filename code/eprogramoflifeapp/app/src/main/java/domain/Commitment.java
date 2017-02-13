package domain;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitment {

    private String description;
    private Frequency frequency;

    public Commitment(String description, Frequency frequency) {
        this.description = description;
        this.frequency = frequency;
    }

    public String getDescription() {
        return description;
    }

    public Frequency getFrequency() {
        return frequency;
    }

}
