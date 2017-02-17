package domain;

import java.util.Date;
import java.util.HashMap;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitment {
    public enum Frequency { Daily, Weekly, Biweekly, Monthly, Yarly }
    public enum Level { Done, Partially, NotDone }

    private String description;
    private Frequency frequency;

    private HashMap<Date, Level> performed;

    public Commitment(String description, Frequency frequency) {
        this.description = description;
        this.frequency = frequency;

        this.performed = new HashMap<>();
    }

    public String getDescription() {
        return description;
    }

    public Frequency getFrequency() {
        return frequency;
    }

    public HashMap<Date, Level> getPerformed()
    {
        return this.performed;
    }

    //Use this method to update values too
    public void Point(Date date, Level level)
    {
        this.performed.put(date, level);
    }

    @Override
    public boolean equals(Object o) {
        return ((Commitment)o).getDescription() == this.description &&
               ((Commitment)o).getFrequency() == this.frequency;
    }

    @Override
    public int hashCode() {
        return this.description.hashCode() + this.frequency.hashCode();
    }
}
