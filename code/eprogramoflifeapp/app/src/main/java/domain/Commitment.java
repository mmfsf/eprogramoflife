package domain;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;

/**
 * Created by marcosfarias on 2/12/17.
 */

public abstract class Commitment implements Serializable {
    public enum Frequency { Daily, Weekly, Biweekly, Monthly, Yarly }
    public enum Level { Done, Partially, NotDone }

    protected String name;
    protected String description;
    protected Frequency frequency;

    protected HashMap<String, Level> performed;
    protected SimpleDateFormat simpleDateFormat;

    public Commitment(String name, Frequency frequency) {
        this.name = name;
        this.frequency = frequency;

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
