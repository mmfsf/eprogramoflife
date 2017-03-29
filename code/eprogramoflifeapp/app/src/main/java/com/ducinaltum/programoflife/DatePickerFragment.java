package com.ducinaltum.programoflife;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
//import android.app.DialogFragment;
import android.os.Bundle;
import android.widget.DatePicker;
import android.widget.TextView;

import java.util.Calendar;
import java.util.Date;
import java.util.StringTokenizer;

import android.support.v4.app.DialogFragment;

/**
 * Created by marcosfarias on 3/17/17.
 */

public class DatePickerFragment extends DialogFragment
        implements DatePickerDialog.OnDateSetListener {

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        // Use the current date as the default date in the picker
        final Calendar c = Calendar.getInstance();
        int year = c.get(Calendar.YEAR);
        int month = c.get(Calendar.MONTH);
        int day = c.get(Calendar.DAY_OF_MONTH);

        // Create a new instance of DatePickerDialog and return it
        return new DatePickerDialog(getActivity(), this, year, month, day);
    }

    public void onDateSet(DatePicker view, int year, int month, int day) {
        // Do something with the date chosen by the user
        TextView tvDate = (TextView)getActivity().findViewById(R.id.tvDate);

        final Calendar c = Calendar.getInstance();
        c.set(year, month, day);

        tvDate.setText(MainActivity.sdfView.format(c.getTime()));
        MainActivity.key = c.getTime();
    }
}