package com.example.leftover

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Close
import androidx.compose.material.icons.filled.KeyboardArrowRight
import androidx.compose.material3.Button
import androidx.compose.material3.Icon
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp


@Composable
fun FilterScreen() {
    Surface(
        color = colorResource(id = R.color.Alabaster)
    ) {
        Column {
            Filters()
        }
    }


}

@Composable
fun Filters(modifier: Modifier = Modifier){
    Column(
        modifier = Modifier
            .padding(10.dp)
            .fillMaxWidth()
            .height(600.dp)
    ) {
        Spacer(modifier = Modifier.weight(0.2f))
        Button(onClick = { /*TODO*/ }) {
            Icon(Icons.Filled.Close, contentDescription = null)
        }
        Spacer(modifier = Modifier.weight(1f))
        Box(
            modifier = Modifier
                .background(color = colorResource(id = R.color.SkyBlue))
                .height(40.dp)
                .clickable { }
        ) {
            Row {
                Text(text = "Category")
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.KeyboardArrowRight, contentDescription = null )
            }

        }
        Spacer(modifier = Modifier.padding(10.dp))
        Box(
            modifier = Modifier
                .background(color = colorResource(id = R.color.SkyBlue))
                .height(40.dp)
                .clickable { }
        )  {
            Row {
                Text(text = "Sorting")
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.KeyboardArrowRight, contentDescription = null )
            }
        }
        Spacer(modifier = Modifier.padding(10.dp))
        Box(
            modifier = Modifier
                .background(color = colorResource(id = R.color.SkyBlue))
                .height(40.dp)
                .clickable { }
        ) {
            Row {
                Text(text = "Distance of Store")
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.KeyboardArrowRight, contentDescription = null )
            }
        }
        Spacer(modifier = Modifier.padding(10.dp))
        Box(
            modifier = Modifier
                .background(color = colorResource(id = R.color.SkyBlue))
                .height(60.dp)
                .clickable { }
        ) {
            Row {
                Text(text = "Min Amount")
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.KeyboardArrowRight, contentDescription = null )
            }
        }
        Spacer(modifier = Modifier.weight(1f))
        Button(onClick = { /*TODO*/ }) {
            Text(text = "Filter")
        }
        Spacer(modifier = Modifier.weight(1f))
    }
}




@Preview
@Composable
fun FilterScreenPreview(){
    FilterScreen(
    )
}