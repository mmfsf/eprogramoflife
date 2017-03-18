package com.ducinaltum.programoflife;

//import android.app.DialogFragment;
import android.content.Context;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.CheckedTextView;
import android.widget.ListView;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import domain.Commitment;
import domain.Commitments;

import android.support.v4.app.DialogFragment;

public class MainActivity extends AppCompatActivity {
    private static final String dataFileName = "data";
    public static SimpleDateFormat sdf;
    public Commitments commitments = new Commitments();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        sdf = new SimpleDateFormat(getString(R.string.date_format));

        TextView tvDate = (TextView)findViewById(R.id.tvDate);
        tvDate.setText(sdf.format(new Date()));

        for (Commitment c: commitments.getCommitments()) {
            int id = getResources().getIdentifier(c.getName(), "string", getPackageName());
            c.setDescription(getString(id));
        }

        List<Commitment> list = new ArrayList<>(commitments.getCommitments());

        CommitmentsAdapter adapter = new CommitmentsAdapter(this, R.layout.list_commitment, list);
        final ListView listView = (ListView) findViewById(R.id.lvCommitments);
        listView.setAdapter(adapter);

        configTextViewDateChangeListener();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void showDatePickerDialog(View v) {
        DialogFragment newFragment = new DatePickerFragment();
        newFragment.show(getSupportFragmentManager(), "datePicker");
    }

    private void configTextViewDateChangeListener()
    {
        final TextView tvDate = (TextView)findViewById(R.id.tvDate);

        tvDate.addTextChangedListener(new TextWatcher() {

            @Override
            public void afterTextChanged(Editable s) { }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) { }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                String key = tvDate.getText().toString().replace("-", "");
                List<Commitment> list = new ArrayList<>(commitments.getCommitmentsOfTheDay(key));
            }
        });
    }
}
