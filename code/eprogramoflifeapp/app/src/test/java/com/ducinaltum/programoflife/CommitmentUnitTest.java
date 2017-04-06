package com.ducinaltum.programoflife;

import org.junit.Test;

import java.text.SimpleDateFormat;
import java.util.Date;

import domain.Commitment;
import domain.MonthlyCommitment;

import static org.junit.Assert.assertEquals;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
public class CommitmentUnitTest {

    private static SimpleDateFormat sdf = new SimpleDateFormat("yyyyMMdd");

    @Test
    public void commitment_isWorking() {
        Commitment c = new MonthlyCommitment("newcommitment", Commitment.Frequency.Monthly);
        assertEquals(c.getName(), "newcommitment");
        assertEquals(c.getFrequency(), Commitment.Frequency.Monthly);
    }

    @Test
    public void commitment_addPerformed() {
        Commitment c = new MonthlyCommitment("newcommitment", Commitment.Frequency.Monthly);
        Date key = new Date();
        c.Point(key, Commitment.Level.Done);
        assertEquals(c.getPerformed(key), Commitment.Level.Done);
    }

    @Test
    public void commitment_updatePerformed() {
        Commitment c = new MonthlyCommitment("newcommitment", Commitment.Frequency.Monthly);
        Date key = new Date();
        c.Point(key, Commitment.Level.Done);
        assertEquals(c.getPerformed(key), Commitment.Level.Done);

        c.Point(key, Commitment.Level.NotDone);
        assertEquals(c.getPerformed(key), Commitment.Level.NotDone);
    }
}