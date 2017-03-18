package com.ducinaltum.programoflife;

import org.junit.Test;

import java.text.SimpleDateFormat;
import java.util.Date;

import domain.Commitment;

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
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        assertEquals(c.getName(), "newcommitment");
        assertEquals(c.getFrequency(), Commitment.Frequency.Monthly);
        assertEquals(c.getPerformed().size(), 0);
    }

    @Test
    public void commitment_addPerformed() {
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        c.Point(sdf.format(new Date()), Commitment.Level.Done);
        assertEquals(c.getPerformed().size(), 1);
    }

    @Test
    public void commitment_updatePerformed() {
        Commitment c = new Commitment("newcommitment", Commitment.Frequency.Monthly);
        String key = sdf.format(new Date());
        c.Point(key, Commitment.Level.Done);
        assertEquals(c.getPerformed().size(), 1);
        assertEquals(c.getPerformed().get(key), Commitment.Level.Done);

        c.Point(key, Commitment.Level.NotDone);
        assertEquals(c.getPerformed().get(key), Commitment.Level.NotDone);
    }
}