package domain;

import java.util.HashSet;

/**
 * Created by marcosfarias on 2/12/17.
 */

public class Commitments {

    private HashSet<Commitment> commitments;

    public Commitments() {
        this.commitments = new HashSet<>();

        commitments.add(new Commitment("mornigoffering", Commitment.Frequency.Daily));
        commitments.add(new Commitment("nightprayers", Commitment.Frequency.Daily));
        commitments.add(new Commitment("dailymeditation", Commitment.Frequency.Daily));
        commitments.add(new Commitment("rosary", Commitment.Frequency.Daily));
        commitments.add(new Commitment("reconciliation", Commitment.Frequency.Monthly));
        commitments.add(new Commitment("angelus", Commitment.Frequency.Monthly));
        commitments.add(new Commitment("visityeucharist", Commitment.Frequency.Daily));
        commitments.add(new Commitment("eucharistichour", Commitment.Frequency.Weekly));
        commitments.add(new Commitment("reflection", Commitment.Frequency.Monthly));
        commitments.add(new Commitment("triduum", Commitment.Frequency.Yarly));
    }

    public HashSet<Commitment> getCommitments() {
        HashSet<Commitment> copy = new HashSet<>();
        copy.addAll(this.commitments);
        return copy;
    }

    public void addCommitment(String name, Commitment.Frequency frequency) {
        this.commitments.add(new Commitment(name, frequency));
    }

    public void addCommitment(Commitment commitment) {
        this.commitments.add(commitment);
    }

    public void removeCommitment(Commitment commitment) {
        this.commitments.remove(commitment);

    }
}
