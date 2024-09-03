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
import androidx.compose.foundation.layout.size
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Close
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.ModalBottomSheet
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.input.pointer.motionEventSpy
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.text.style.LineBreak
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp

@Composable
fun ReservationsScreen(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onReservationScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onGoBackButtonClicked: () -> Unit,
    onDetailsButtonClicked: () -> Unit
) {
   Surface(
       color = colorResource(id = R.color.Alabaster)
   ) {
       Column(modifier = Modifier.fillMaxSize()) {
           ReservationsInfo(
                onGoBackButtonClicked = onGoBackButtonClicked,
                onDetailsButtonClicked = onDetailsButtonClicked
           )
       }
   }
}

@Composable
fun ReservationsInfo(
    onGoBackButtonClicked: () -> Unit,
    onDetailsButtonClicked: () ->Unit
){
    Column(
        modifier = Modifier
            .padding(10.dp)
            .height(610.dp)
            .fillMaxWidth()
    ) {
        IconButton(onClick = { onGoBackButtonClicked() }) {
            Icon(Icons.Filled.Close, contentDescription = null, modifier = Modifier.size(30.dp))
        }
        Spacer(modifier = Modifier.weight(0.1f))
        Box(modifier = Modifier
            .background(colorResource(id = R.color.SkyBlue))
            .padding(10.dp)){
            Column {
                Row {
                    Column {
                        Text(text = "Business Name")
                        Text(text = "Total Cost")
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    Column {
                        Spacer(modifier = Modifier.padding(10.dp))
                        Text(
                            text = "Details >",
                            modifier = Modifier.clickable {
                            onDetailsButtonClicked ()
                            }
                        )
                    }
                }
                Spacer(modifier = Modifier.padding(10.dp))
                Text(text = "Delivered/Cancel")
            }
        }
        Spacer(modifier = Modifier.weight(0.2f))
        Box(modifier = Modifier
            .background(colorResource(id = R.color.SkyBlue))
            .padding(10.dp)){
            Column {
                Row {
                    Column {
                        Text(text = "Business Name")
                        Text(text = "Total Cost")
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    Column {
                        Spacer(modifier = Modifier.padding(10.dp))
                        Text(text = "Details >")
                    }
                }
                Spacer(modifier = Modifier.padding(10.dp))
                Text(text = "Delivered/Cancel")
            }
        }
        Spacer(modifier = Modifier.weight(1f))
    }
}


@Preview
@Composable
fun ReservationsScreenPreview() {
    ReservationsScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onReservationScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onGoBackButtonClicked = {},
        onDetailsButtonClicked = {}
    )
}