package domain;

import android.content.Context;
import android.content.res.Resources;

import java.util.List;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitments {

    private List<Commitment> commitments;

    public Commitments()
    {
        commitments.add(new Commitment("mornigoffering", Frequency.Daily));
        commitments.add(new Commitment("nightprayers", Frequency.Daily));
        commitments.add(new Commitment("dailymeditation", Frequency.Daily));
        commitments.add(new Commitment("rosary", Frequency.Daily));
        commitments.add(new Commitment("confession", Frequency.Monthly));
    }

    public List<Commitment> getCommitments() {
        return commitments;
    }
}
