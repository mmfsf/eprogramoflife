package domain;

import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by mmfsf on 3/29/17.
 */

public class YarlyCommitment extends Commitment {

    public YarlyCommitment(String name, Frequency frequency) {
        super(name, frequency);
        simpleDateFormat = new SimpleDateFormat("yyyy");
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
