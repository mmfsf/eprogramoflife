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

        commitments.add(new DailyCommitment("mornigoffering"));
        commitments.add(new DailyCommitment("nightprayers"));
        commitments.add(new DailyCommitment("dailymeditation"));
        commitments.add(new DailyCommitment("rosary"));
        commitments.add(new DailyCommitment("visityeucharist"));
        commitments.add(new DailyCommitment("angelus"));
        commitments.add(new WeeklyCommitment("eucharistichour"));
        commitments.add(new MonthlyCommitment("reconciliation"));
        commitments.add(new MonthlyCommitment("reflection"));
        commitments.add(new YearlyCommitment("triduum"));
    }

    public HashSet<Commitment> getCommitments() {
        return this.commitments;
    }

    public void addCommitment(String name, Commitment.Frequency frequency) {
        switch (frequency)
        {
            case Daily:
                this.commitments.add(new DailyCommitment(name));
                break;
            case Weekly:
                this.commitments.add(new WeeklyCommitment(name));
                break;
            case Biweekly:
                break;
            case Monthly:
                this.commitments.add(new MonthlyCommitment(name));
                break;
            case Yearly:
                this.commitments.add(new YearlyCommitment(name));
                break;
        }
    }

    public void addCommitment(Commitment commitment) {
        this.commitments.add(commitment);
    }

    public void removeCommitment(Commitment commitment) {
        this.commitments.remove(commitment);
    }
}
