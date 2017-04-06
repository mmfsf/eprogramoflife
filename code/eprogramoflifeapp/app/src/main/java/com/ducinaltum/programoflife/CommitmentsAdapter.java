package com.ducinaltum.programoflife;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.StringTokenizer;

import domain.Commitment;

/**
 * Created by marcosfarias on 3/13/17.
 */

public class CommitmentsAdapter extends ArrayAdapter<Commitment> {

    public CommitmentsAdapter(Context context, int textViewResourceId) {
        super(context, textViewResourceId);
    }

    public CommitmentsAdapter(Context context, int resource, List<Commitment> data) {
        super(context, resource, data);
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View v = convertView;

        if (v == null) {
            LayoutInflater vi;
            vi = LayoutInflater.from(getContext());
            v = vi.inflate(R.layout.list_commitment, null);
        }

        Commitment p = getItem(position);

        if (p != null) {
            TextView tt1 = (TextView) v.findViewById(R.id.tvDescription);
            TextView tt2 = (TextView) v.findViewById(R.id.tvFrequency);
            RadioButton rbDone = (RadioButton) v.findViewById(R.id.rbDone);
            RadioButton rbPartially = (RadioButton) v.findViewById(R.id.rbPartially);
            RadioButton rbNotDone = (RadioButton) v.findViewById(R.id.rbNotDone);

            if (tt1 != null) {
                tt1.setText(p.getDescription());
            }

            if(tt2 != null) {
                tt2.setText(p.getFrequencyDescription());
            }

            final Commitment.Level level = p.getPerformed(MainActivity.key);

            switch (level) {
                case Done:
                    rbDone.toggle();
                    break;
                case Partially:
                    rbPartially.toggle();
                    break;
                case NotDone:
                    rbNotDone.toggle();
                    break;
            }

            RegisterRadioGroupListener(position, v);
        }

        return v;
    }

    private void RegisterRadioGroupListener(final int position, View v) {
        RadioGroup rg = (RadioGroup) v.findViewById(R.id.rgCommitmentLevel);
        rg.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, int checkedId) {
                RadioButton rb = (RadioButton) group.findViewById(checkedId);
                switch (rb.getId()) {
                    case R.id.rbDone:
                        UpdateCommitmentLevel(position, Commitment.Level.Done);
                        break;
                    case R.id.rbPartially:
                        UpdateCommitmentLevel(position, Commitment.Level.Partially);
                        break;
                    case R.id.rbNotDone:
                        UpdateCommitmentLevel(position, Commitment.Level.NotDone);
                        break;
                }
            }
        });
    }

    private void UpdateCommitmentLevel(int position, Commitment.Level level)
    {
        Commitment c = getItem(position);
        c.Point(MainActivity.key, level);
    }
}