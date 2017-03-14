package com.ducinaltum.programoflife;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import domain.Commitment;

/**
 * Created by marcosfarias on 3/13/17.
 */

public class CommitmentsAdapter extends ArrayAdapter<Commitment> {
    private ArrayList<Commitment> dataSet;
    Context mContext;

    public CommitmentsAdapter(Context context, int textViewResourceId) {
        super(context, textViewResourceId);
    }

    public CommitmentsAdapter(Context context, int resource, List<Commitment> data) {
        super(context, resource, data);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View v = convertView;

        if (v == null) {
            LayoutInflater vi;
            vi = LayoutInflater.from(getContext());
            v = vi.inflate(R.layout.list_commitment, null);
        }

        Commitment p = getItem(position);

        if (p != null) {
            TextView tt1 = (TextView) v.findViewById(R.id.tvDescription);
            CheckBox cbDone = (CheckBox) v.findViewById(R.id.cbDone);
            CheckBox cbPartially = (CheckBox) v.findViewById(R.id.cbPartialy);
            CheckBox cbNotDone = (CheckBox) v.findViewById(R.id.cbNotDone);

            if (tt1 != null) {
                tt1.setText(p.getDescription());
            }

            Commitment.Level level = Commitment.Level.NotDone; //p.getPerformed().get(new Date());

            switch (level){
                case Done:
                    cbDone.setChecked(true);
                    cbPartially.setChecked(false);
                    cbNotDone.setChecked(false);
                    break;
                case Partially:
                    cbDone.setChecked(false);
                    cbPartially.setChecked(true);
                    cbNotDone.setChecked(false);
                    break;
                case NotDone:
                    cbDone.setChecked(false);
                    cbPartially.setChecked(false);
                    cbNotDone.setChecked(true);
                    break;
            }
        }

        return v;
    }

}