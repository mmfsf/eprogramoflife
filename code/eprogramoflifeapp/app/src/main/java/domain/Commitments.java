package domain;

import java.io.Serializable;
import java.util.HashSet;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitments implements Serializable {

    private HashSet<Commitment> commitments;

    public Commitments() {
        this.commitments = new HashSet<>();

        commitments.add(new DailyCommitment("mornigoffering", Commitment.Frequency.Daily));
        commitments.add(new DailyCommitment("nightprayers", Commitment.Frequency.Daily));
        commitments.add(new DailyCommitment("dailymeditation", Commitment.Frequency.Daily));
        commitments.add(new DailyCommitment("rosary", Commitment.Frequency.Daily));
        commitments.add(new DailyCommitment("visityeucharist", Commitment.Frequency.Daily));
        commitments.add(new WeeklyCommitment("eucharistichour", Commitment.Frequency.Weekly));
        commitments.add(new MonthlyCommitment("reconciliation", Commitment.Frequency.Monthly));
        commitments.add(new MonthlyCommitment("angelus", Commitment.Frequency.Monthly));
        commitments.add(new MonthlyCommitment("reflection", Commitment.Frequency.Monthly));
        commitments.add(new YarlyCommitment("triduum", Commitment.Frequency.Yarly));
    }

    public HashSet<Commitment> getCommitments() {
        return this.commitments;
    }

    public void addCommitment(String name, Commitment.Frequency frequency) {
        this.commitments.add(new DailyCommitment(name, frequency));
    }

    public void addCommitment(Commitment commitment) {
        this.commitments.add(commitment);
    }

    public void removeCommitment(Commitment commitment) {
        this.commitments.remove(commitment);

    }
}
