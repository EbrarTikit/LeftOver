package com.example.leftover

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Info
import androidx.compose.material.icons.filled.KeyboardArrowLeft
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.OutlinedTextFieldDefaults
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import org.w3c.dom.Text

@Composable
fun NewLocationScreen(
    onBackButtonClicked: () -> Unit,
    onSaveMyLocationButtonClicked: () -> Unit
){
    Surface( modifier = Modifier.fillMaxSize()) {
        Column(
            horizontalAlignment = Alignment.CenterHorizontally,
            verticalArrangement = Arrangement.Center
        ) {
            Row(modifier = Modifier
                .fillMaxWidth()
                .background(colorResource(id = R.color.Alabaster)), verticalAlignment = Alignment.CenterVertically) {
                IconButton(onClick = onBackButtonClicked) {
                    Icon(Icons.Filled.KeyboardArrowLeft, contentDescription = null)
                }
                Spacer(modifier = Modifier.weight(0.05f))
                Text(text = "LocationDetails")
                Spacer(modifier = Modifier.weight(1f))
            }
            Row(horizontalArrangement = Arrangement.Center, verticalAlignment = Alignment.CenterVertically) {
                Box(modifier = Modifier.padding(5.dp)) {
                    Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null)
                }
            }
            Box(modifier = Modifier
                .padding(10.dp)
                .fillMaxWidth()) {
                Column(
                    modifier = Modifier.fillMaxWidth()
                ){
                    Row(verticalAlignment = Alignment.CenterVertically) {
                        IconButton(onClick = { /*TODO*/ }) {
                            Icon(Icons.Filled.Info, contentDescription = null, tint = colorResource(
                                id = R.color.SkyBlue
                            ) )
                        }
                        Text(text = "Show my current location", color = colorResource(id = R.color.SkyBlue))
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    OutlinedTextField(value = "avenue, street and other information", onValueChange = {}  )
                    Spacer(modifier = Modifier.weight(1f))
                    Row {
                        OutlinedTextField(value = "city", onValueChange = {}, modifier = Modifier.weight(1f) )
                        Spacer(modifier = Modifier.weight(0.05f))
                        OutlinedTextField(value = "town", onValueChange = {},modifier = Modifier.weight(1f) )
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    OutlinedTextField(value = "neighbourhood", onValueChange = {} )
                    Spacer(modifier = Modifier.weight(1f))
                    Row {
                        OutlinedTextField(value = "building no", onValueChange = {}, modifier = Modifier.weight(1f) )
                        Spacer(modifier = Modifier.weight(0.05f))
                        OutlinedTextField(value = "floor", onValueChange = {}, modifier = Modifier.weight(0.8f) )
                        Spacer(modifier = Modifier.weight(0.05f))
                        OutlinedTextField(value = "apartment no", onValueChange = {}, modifier = Modifier.weight(1f) )
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    OutlinedTextField(value = "address direction", onValueChange = {} )
                    Spacer(modifier = Modifier.weight(1f))
                    OutlinedTextField(value = "address name", onValueChange = {} )
                    Spacer(modifier = Modifier.weight(1f))
                    Text(text = "Contact information", color = colorResource(id = R.color.SkyBlue))
                    Spacer(modifier = Modifier.weight(1f))
                    Row {
                        OutlinedTextField(value = "name", onValueChange = {}, modifier = Modifier.weight(1f) )
                        Spacer(modifier = Modifier.weight(0.05f))
                        OutlinedTextField(value = "surname", onValueChange = {}, modifier = Modifier.weight(1f) )
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    OutlinedTextField(value = "phone number", onValueChange = {})
                    Row(horizontalArrangement = Arrangement.Center, modifier = Modifier.fillMaxWidth()) {
                        Button(onClick = onSaveMyLocationButtonClicked, colors =ButtonDefaults.buttonColors(
                            colorResource(id = R.color.Blue))) {
                            Text(text = "Save my location")
                        }
                    }

                }
            }
        }
    }
}
@Preview
@Composable
fun NewLocationScreenPreview() {
    NewLocationScreen(
        onBackButtonClicked = { /*TODO*/ },
        onSaveMyLocationButtonClicked = {}
    )
}