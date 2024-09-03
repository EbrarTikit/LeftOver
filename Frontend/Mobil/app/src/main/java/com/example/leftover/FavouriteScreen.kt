package com.example.leftover

import android.widget.Space
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.List
import androidx.compose.material.icons.filled.Star
import androidx.compose.material3.Card
import androidx.compose.material3.Icon
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.focus.focusModifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp


@Composable
fun FavouriteScreen(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onBasketScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onRestaurantBoxClicked: () -> Unit,
    onLocationButtonClicked: () -> Unit

){
    Scaffold(
        topBar = { UpPart(onLocationButtonClicked) },
        bottomBar = {
            BottomPart(
                onHomePageButtonClicked = onHomePageButtonClicked,
                onFavouritePageButtonClicked = onFavouritePageButtonClicked,
                onBasketScreensButtonClicked = onBasketScreensButtonClicked,
                onProfilePageButtonClicked = onProfilePageButtonClicked
            )
        }
    ) {innerPadding ->
        Column(modifier = Modifier.padding(innerPadding)) {
            FavouriteInfo(
                onRestaurantBoxClicked = onRestaurantBoxClicked
            )
        }

    }
}

@Composable
fun FavouriteInfo(
    onRestaurantBoxClicked: () -> Unit
){
    Column(
        modifier = Modifier
            .padding(10.dp)
            .fillMaxWidth()
            .height(600.dp),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ){
        Row(
            modifier = Modifier.padding(20.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            Text(text = "Favourites")
            Spacer(modifier = Modifier.weight(1f))
        }
        Column(modifier = Modifier.padding(20.dp)) {
            Box(
                modifier = Modifier
                    .background(colorResource(id = R.color.SkyBlue))
                    .clickable {
                        onRestaurantBoxClicked()
                    }
            ){
                Column(horizontalAlignment = Alignment.CenterHorizontally) {
                    Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null )
                    Row(modifier = Modifier.fillMaxWidth()) {
                        Text(text = "Name of Business")
                        Spacer(modifier = Modifier.weight(1f))
                        Text(text = "Time Interval")
                    }
                    Row(modifier = Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically) {
                        Icon(Icons.Filled.Star, contentDescription = null )
                        Text(text = "Rate | Distance")
                    }
                }
            }
            Spacer(modifier = Modifier.weight(1f))
            Box(
                modifier = Modifier
                    .background(colorResource(id = R.color.SkyBlue))
                    .clickable {
                        onRestaurantBoxClicked()
                    }
            ){
                Column(
                    horizontalAlignment = Alignment.CenterHorizontally,

                    ) {
                    Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null )
                    Row(modifier = Modifier.fillMaxWidth()) {
                        Text(text = "Name of Business")
                        Spacer(modifier = Modifier.weight(1f))
                        Text(text = "Time Interval")
                    }
                    Row(modifier = Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically) {
                        Icon(Icons.Filled.Star, contentDescription = null )
                        Text(text = "Rate | Distance")
                    }
                }
            }
            Spacer(modifier = Modifier.weight(1f))
        }
    }
}


@Preview
@Composable
fun FavouriteScreenPreview(){
    FavouriteScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onBasketScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onRestaurantBoxClicked = {},
        onLocationButtonClicked = {}
    )
}

