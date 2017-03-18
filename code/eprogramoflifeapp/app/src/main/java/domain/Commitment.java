package domain;

import java.util.HashMap;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitment {
    public enum Frequency { Daily, Weekly, Biweekly, Monthly, Yarly }
    public enum Level { Done, Partially, NotDone }

    private String name;
    private String description;
    private Frequency frequency;

    private HashMap<String, Level> performed;

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

    public HashMap<String, Level> getPerformed()
    {
        return this.performed;
    }

    //Use this method to update values too
    public void Point(String key, Level level)
    {
        this.performed.put(key, level);
    }

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
