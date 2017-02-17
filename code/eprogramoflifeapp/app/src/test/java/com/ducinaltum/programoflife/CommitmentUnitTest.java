package com.ducinaltum.programoflife;

import org.junit.Test;

import java.util.Date;
import java.util.HashMap;

import domain.Commitment;
import domain.Commitments;

import static org.junit.Assert.assertEquals;

/**
 * Example local unit test, which will execute on the development machine (host).
 *
 * @see <a href="http://d.android.com/tools/testing">Testing documentation</a>
 */
public class CommitmentUnitTest {

    @Test
    public void commitment_isWorking() {
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        assertEquals(c.getDescription(), "newcommitment");
        assertEquals(c.getFrequency(), Commitment.Frequency.Monthly);
        assertEquals(c.getPerformed().size(), 0);
    }

    @Test
    public void commitment_addPerformed() {
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        c.Point(new Date(), Commitment.Level.Done);
        assertEquals(c.getPerformed().size(), 1);
    }

    @Test
    public void commitment_updatePerformed() {
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        Date d = new Date();
        c.Point(d, Commitment.Level.Done);
        assertEquals(c.getPerformed().size(), 1);
        assertEquals(c.getPerformed().get(d), Commitment.Level.Done);

        c.Point(d, Commitment.Level.NotDone);
        assertEquals(c.getPerformed().get(d), Commitment.Level.NotDone);
    }
}