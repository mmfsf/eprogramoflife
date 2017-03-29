package domain;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.StringTokenizer;

/**
 * Created by mmfsf on 3/29/17.
 */

public class DailyCommitment extends Commitment {

    public DailyCommitment(String name, Frequency frequency)
    {
        super(name, frequency);
        simpleDateFormat = new SimpleDateFormat("yyyyMMdd");
    }

    public Level getPerformed(Date date)
    {
        String key = simpleDateFormat.format(date);

        Level level = this.performed.get(key);
        if(level == null)
        {
            level = Level.NotDone;
        }
        return level;
    }

    public void Point(Date date, Level level)
    {
        String key = simpleDateFormat.format(date);
        this.performed.put(key, level);
    }
}
