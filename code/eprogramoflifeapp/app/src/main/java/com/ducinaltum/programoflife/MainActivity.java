package com.ducinaltum.programoflife;

//import android.app.DialogFragment;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.DialogFragment;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import domain.Commitment;
import domain.Commitments;
import domain.InternalStorage;

public class MainActivity extends AppCompatActivity {
    private static final String dataFileName = "DATA";

    public static SimpleDateFormat sdfView;
    public static Date key;

    private Commitments commitments;
    private CommitmentsAdapter adapter;
    private List<Commitment> list;

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

        sdfView = new SimpleDateFormat(getString(R.string.date_format));
        key = new Date();

        TextView tvDate = (TextView)findViewById(R.id.tvDate);
        tvDate.setText(sdfView.format(key));

        try {
            commitments = (Commitments)InternalStorage.readObject(this, dataFileName);
        }
        catch (IOException ex)
        {
            commitments = new Commitments();
            Toast.makeText(this, "OnCreateErro", Toast.LENGTH_SHORT).show();
        }
        catch (ClassNotFoundException e){
            commitments = new Commitments();
        }

        for (Commitment c: commitments.getCommitments()) {
            int id = getResources().getIdentifier(c.getName(), "string", getPackageName());
            c.setDescription(getString(id));
        }

        list = new ArrayList<>(commitments.getCommitments());

        adapter = new CommitmentsAdapter(this, R.layout.list_commitment, list);
        final ListView listView = (ListView) findViewById(R.id.lvCommitments);
        listView.setAdapter(adapter);

        configTextViewDateChangeListener();
    }

    @Override
    protected void onPause() {
        super.onPause();
        try {
            InternalStorage.writeObject(this, dataFileName, commitments);
        }
        catch (IOException e)
        {
            Toast.makeText(this, "OnPauseErro", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        if(commitments == null) {
            try {
                commitments = (Commitments) InternalStorage.readObject(this, dataFileName);
            } catch (IOException ex) {
                commitments = new Commitments();
                Toast.makeText(this, "OnResumeIOErro", Toast.LENGTH_SHORT).show();
            } catch (ClassNotFoundException e) {
                commitments = new Commitments();
                Toast.makeText(this, "OnResumeClassErro", Toast.LENGTH_SHORT).show();
            }
        }
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
            startActivity(new Intent(this, SettingsActivity.class));
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
                adapter.notifyDataSetChanged();
            }
        });
    }
}
