package domain;

import java.util.Calendar;
import java.util.Date;

/**
 * Created by mmfsf on 3/29/17.
 */

public class WeeklyCommitment extends Commitment {
    public WeeklyCommitment(String name) {
        super(name);
        this.frequency = Frequency.Weekly;
    }

    public Level getPerformed(Date date)
    {
        String key = GetKey(date);

        Level level = this.performed.get(key);
        if(level == null)
        {
            level = Level.NotDone;
        }
        return level;
    }

    public void Point(Date date, Level level)
    {
        String key = GetKey(date);
        this.performed.put(key, level);
    }

    private String GetKey(Date date)
    {
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(date);
        int year = calendar.get(Calendar.YEAR);
        int numberOfDays = calendar.get(Calendar.MONTH) * 30;
        int week = (int)Math.ceil(numberOfDays / 7.0);

        return String.format("%d%d", year, week);
    }
}
