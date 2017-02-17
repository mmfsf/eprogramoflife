package domain;

import android.content.Context;
import android.content.res.Resources;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitments {

    private List<Commitment> commitments;

    public Commitments()
    {
        this.commitments = new ArrayList<>();

        commitments.add(new Commitment("mornigoffering", Commitment.Frequency.Daily));
        commitments.add(new Commitment("nightprayers", Commitment.Frequency.Daily));
        commitments.add(new Commitment("dailymeditation", Commitment.Frequency.Daily));
        commitments.add(new Commitment("rosary", Commitment.Frequency.Daily));
        commitments.add(new Commitment("confession", Commitment.Frequency.Monthly));
        commitments.add(new Commitment("angelus", Commitment.Frequency.Monthly));
    }

    public List<Commitment> getCommitments() {
        List<Commitment> copy = new ArrayList<>();
        copy.addAll(this.commitments);
        return copy;
    }
}
