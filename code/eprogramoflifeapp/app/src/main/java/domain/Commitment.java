package domain;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;

/**
 * Created by marcosfarias on 2/12/17.
 */

public abstract class Commitment implements Serializable {
    public enum Frequency { Daily, Weekly, Biweekly, Monthly, Yearly }
    public enum Level { Done, Partially, NotDone }

    protected String name;
    protected String description;
    protected Frequency frequency;
    protected String frequencyDescription;

    protected HashMap<String, Level> performed;
    protected SimpleDateFormat simpleDateFormat;

    public Commitment(String name) {
        this.name = name;

        this.performed = new HashMap<>();
    }

    public String getName() {
        return name;
    }

    public String getDescription() { return description; }

    public void setDescription(String description) { this.description = description; }

    public Frequency getFrequency() {
        return frequency;
    }

    public String getFrequencyDescription() {
        return frequencyDescription;
    }

    public void setFrequencyDescription(String frequencyDescription) {
        this.frequencyDescription = frequencyDescription;
    }

    public abstract Level getPerformed(Date date);

    public abstract void Point(Date date, Level level);

    @Override
    public boolean equals(Object o) {
        return ((Commitment)o).getName() == this.name &&
               ((Commitment)o).getFrequency() == this.frequency;
    }

    @Override
    public int hashCode() {
        return this.name.hashCode() + this.frequency.hashCode();
    }
}
