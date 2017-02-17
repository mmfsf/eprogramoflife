package domain;

import java.util.Date;
import java.util.HashMap;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitment {
    public enum Frequency { Daily, Weekly, Biweekly, Monthly }
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

    public void Point(Date date, Level level)
    {
        this.performed.put(date, level);
    }
}
