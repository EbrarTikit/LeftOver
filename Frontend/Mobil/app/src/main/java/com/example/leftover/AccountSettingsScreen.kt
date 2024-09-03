package com.example.leftover

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.offset
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.text.BasicTextField
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.paint
import androidx.compose.ui.draw.scale
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp


@Composable
fun AccountSettingsScreen(
    onLocationsButtonClicked: () -> Unit,
    onSaveButtonClicked: () -> Unit,
) {
    Surface(
        color = colorResource(id = R.color.white)
    ) {
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(start = 10.dp, end = 10.dp, bottom = 10.dp)
        ) {
            Row(modifier = Modifier.fillMaxWidth()) {
                Spacer(modifier = Modifier.weight(0.4f))
                Button(
                    onClick = { onLocationsButtonClicked() },
                    modifier = Modifier.padding(5.dp),
                    colors = ButtonDefaults.buttonColors(colorResource(id = R.color.SkyBlue))
                ) {
                    Text(text = "Location")
                    Icon(Icons.Filled.KeyboardArrowDown, contentDescription = null )
                }
                Spacer(modifier = Modifier.weight(1f))
                Image(
                    painter = painterResource(id = R.drawable.leftoverlogo_bgremoved),
                    contentDescription = null,
                    modifier = Modifier
                        .size(90.dp)
                        .offset(x = (-10).dp, y = (-10).dp)
                )
            }

            Text(text = "Account Settings", fontWeight = FontWeight.Bold, fontSize = 18.sp)
            Spacer(modifier = Modifier.weight(0.05f))
            Row {
                TextField(
                    modifier = Modifier
                        .weight(1f)
                        .background(colorResource(id = R.color.Alabaster)),
                    value = "Name",
                    onValueChange = {},
                )
                Spacer(modifier = Modifier.weight(0.05f))
                TextField(value = "Surname", onValueChange = {}, modifier = Modifier.weight(1f))
            }
            Spacer(modifier = Modifier.weight(0.05f))
            TextField(value = "Email", onValueChange = {}, modifier = Modifier.fillMaxWidth())
            Spacer(modifier = Modifier.weight(0.05f))
            TextField(value = "Phone Number", onValueChange = {}, modifier = Modifier.fillMaxWidth())
            Spacer(modifier = with(Modifier) { weight(0.1f) })
            Text(text = "Change Password", fontWeight = FontWeight.Bold, fontSize = 18.sp)
            Spacer(modifier = Modifier.weight(0.05f))
            TextField(value = "Your current password", onValueChange = {}, modifier = Modifier.fillMaxWidth())
            Spacer(modifier = Modifier.weight(0.05f))
            TextField(value = "Your new password", onValueChange = {}, modifier = Modifier.fillMaxWidth())
            Spacer(modifier = Modifier.weight(1f))
            Row {
                Spacer(modifier = Modifier.weight(0.5f))
                Button(
                    onClick = { onSaveButtonClicked() },
                    modifier = Modifier.weight(1f),
                    colors = ButtonDefaults.buttonColors(colorResource(id = R.color.Blue))
                ) {
                    Text(
                        text = "SAVE",
                        fontWeight = FontWeight.Bold,
                    )
                }
                Spacer(modifier = Modifier.weight(0.5f))
            }
            Spacer(modifier = Modifier.weight(0.1f))
        }
    }
}

@Preview
@Composable
fun AccountSettingsPreview() {
    AccountSettingsScreen(
        onLocationsButtonClicked = {},
        onSaveButtonClicked = {}
    )
}