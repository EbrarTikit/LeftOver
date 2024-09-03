package com.example.leftover

import androidx.compose.foundation.background
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
import androidx.compose.material.icons.filled.KeyboardArrowLeft
import androidx.compose.material.icons.filled.Star
import androidx.compose.material.icons.outlined.Star
import androidx.compose.material.icons.sharp.Star
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.text.TextRange
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp


@Composable
fun ReservationsDetailsScreen(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onReservationScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onGoBackButtonClicked: () -> Unit,
    onLocationButtonClicked: () -> Unit
) {
    Surface(
        color = colorResource(id = R.color.Alabaster)
    ) {
        Column(Modifier.fillMaxSize()) {
            ReservationDetailsInfo(
                onGoBackButtonClicked = onGoBackButtonClicked
            )
        }
    }
}


@Composable
fun ReservationDetailsInfo(
    onGoBackButtonClicked: () -> Unit
) {
    Column(
        modifier = Modifier
            .padding(10.dp)
            .height(600.dp)
            .fillMaxWidth()
    ) {
        IconButton(onClick = { onGoBackButtonClicked() }){
            Icon(Icons.Filled.KeyboardArrowLeft, contentDescription = null, modifier = Modifier.size(30.dp)) }
        Box(modifier = Modifier
            .fillMaxWidth()
            .padding(10.dp)
            .background(colorResource(id = R.color.SkyBlue))) {
            Text(text = "Bussines Name", fontWeight = FontWeight.Bold, fontSize = 20.sp, modifier = Modifier.padding(10.dp))
        }
        Box(modifier = Modifier
            .fillMaxWidth()
            .padding(10.dp)
            .background(colorResource(id = R.color.SkyBlue))) {
            Column(modifier = Modifier.padding(10.dp)) {
                Text(text = "Reservation Name: Usta Dönerci - Döner")
                Spacer(modifier = Modifier.padding(3.dp))
                Text(text = "Reservation Time: 17.00 - 18.00")
                Spacer(modifier = Modifier.padding(3.dp))
                Text(text = "Reservation Code: 123456789")
                Spacer(modifier = Modifier.padding(3.dp))
                Text(text = "Total Cost: 250$")
            }
        }

        Box(modifier = Modifier
            .fillMaxWidth()
            .padding(10.dp)
            .background(colorResource(id = R.color.SkyBlue))
        ) {
            Column(modifier = Modifier.padding(10.dp)) {
                Text(text = "Rating")
                Spacer(modifier = Modifier.padding(5.dp))
                Row {
                    Icon(Icons.Filled.Star, contentDescription = null, modifier = Modifier.size(30.dp))
                    Spacer(modifier = Modifier.padding(5.dp))
                    Icon(Icons.Filled.Star, contentDescription = null, modifier = Modifier.size(30.dp))
                    Spacer(modifier = Modifier.padding(5.dp))
                    Icon(Icons.Filled.Star, contentDescription = null, modifier = Modifier.size(30.dp))
                    Spacer(modifier = Modifier.padding(5.dp))
                    Icon(Icons.Filled.Star, contentDescription = null, modifier = Modifier.size(30.dp))
                    Spacer(modifier = Modifier.padding(5.dp))
                    Icon(Icons.Filled.Star, contentDescription = null, modifier = Modifier.size(30.dp))
                }
            }
        }

    }
}

@Preview
@Composable
fun ReservationDetailsScreenPreview() {
    ReservationsDetailsScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onReservationScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onGoBackButtonClicked = {},
        onLocationButtonClicked = {}
    )
}