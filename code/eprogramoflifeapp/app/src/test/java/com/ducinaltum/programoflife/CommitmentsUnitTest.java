package com.ducinaltum.programoflife;

import android.support.v4.media.MediaMetadataCompat;

import org.junit.Test;

import domain.Commitment;
import domain.Commitments;
import domain.MonthlyCommitment;
import domain.YearlyCommitment;

import static org.junit.Assert.*;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
public class CommitmentsUnitTest {

    @Test
    public void commitments_isWorking() {
        Commitments commitments = new Commitments();
        assertEquals(commitments.getCommitments().size(), 10);
    }

    @Test
    public void commitments_addCommitment(){
        Commitments commitments = new Commitments();

        commitments.addCommitment("newcommitment", Commitment.Frequency.Monthly);
        assertEquals(commitments.getCommitments().size(), 11);
    }

    @Test
    public void commitments_removeCommitment(){
        Commitments commitments = new Commitments();

        commitments.removeCommitment(new YearlyCommitment("triduum"));
        assertEquals(commitments.getCommitments().size(), 9);
    }

    @Test
    public void commitments_addExistingCommitment() {
        Commitments commitments = new Commitments();
        commitments.addCommitment("newcommitment", Commitment.Frequency.Monthly);
        commitments.addCommitment("newcommitment", Commitment.Frequency.Monthly);
        assertEquals(commitments.getCommitments().size(), 11);
    }

    @Test
    public void commitments_removeNonExistCommitment() {
        Commitments commitments = new Commitments();

        commitments.removeCommitment(new MonthlyCommitment("newcommitment"));
        assertEquals(commitments.getCommitments().size(), 10);
    }
}