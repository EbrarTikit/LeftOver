package com.example.leftover

import androidx.compose.foundation.Image
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.material3.Card
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.layout.ContentScale
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.FavoriteBorder
import androidx.compose.material.icons.outlined.Favorite
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Alignment
import androidx.navigation.NavController
import com.example.leftover.Data.AllRestaurant

@Composable
fun HomePageScreen(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked : () -> Unit,
    onBasketScreensButtonClicked : () -> Unit,
    onProfilePageButtonClicked : () -> Unit,
    onRestaurantCardClicked: () -> Unit,
    onLocationButtonClicked: () -> Unit,
    viewModel: FoodLeftOverViewModel = viewModel(),
    navController: NavController
){

    val restaurantList by viewModel.restaurantList.observeAsState(initial = emptyList())
    Scaffold(
        topBar = { UpPart(onLocationButtonClicked = onLocationButtonClicked) },
        bottomBar = {
            BottomPart(
                onHomePageButtonClicked = onHomePageButtonClicked,
                onFavouritePageButtonClicked = onFavouritePageButtonClicked,
                onBasketScreensButtonClicked = onBasketScreensButtonClicked,
                onProfilePageButtonClicked = onProfilePageButtonClicked
            )
        }
    ) { innerPadding ->
        Column(modifier = Modifier.padding(innerPadding)) {
            if (restaurantList != null) {
                RestaurantList(restaurantList = restaurantList, onRestaurantCardClicked = onRestaurantCardClicked, navController = navController)
            }
        }
    }

}


@Composable
fun RestaurantCard(
    onRestaurantCardClicked: () -> Unit,
    restaurantName: String,
    restaurantType: String,
    restaurantId: Int,
    navController: NavController
){

    Card(
        modifier = Modifier
            .clickable { navController.navigate("Restaurant/$restaurantId") }
            .padding(10.dp)
    ) {
        Box(modifier = Modifier.fillMaxSize()) {
            Column {
                Image(
                    painter = painterResource(id = R.drawable.foodleftover),
                    contentDescription = null,
                    modifier = Modifier
                        .fillMaxWidth()
                        .height(194.dp),
                    contentScale = ContentScale.Crop
                )
                Row(modifier = Modifier.padding(5.dp)) {
                    Text(text = restaurantName)
                    Spacer(modifier = Modifier.weight(1f))
                    Text(text = restaurantType)
                }
            }

            IconButton(
                onClick = { /*TODO*/ },
                modifier = Modifier
                    .align(Alignment.TopEnd)
                    .padding(10.dp) // Adjust the padding as needed
            ) {
                Icon(Icons.Default.FavoriteBorder, contentDescription = null)
            }
        }
    }

}

@Composable
fun RestaurantList(
    restaurantList: List<AllRestaurant>,
    modifier: Modifier = Modifier,
    onRestaurantCardClicked: () -> Unit,
    navController: NavController) {
    LazyColumn(modifier = modifier) {
        items(restaurantList) { restaurant ->
            RestaurantCard(
                onRestaurantCardClicked = { } ,
                restaurantName = restaurant.name,
                restaurantType = restaurant.storeType,
                restaurantId = restaurant.id,
                navController = navController
            )

        }
    }
}

/*
@Preview
@Composable
fun HomePageScreenPreview(){
    HomePageScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked= {},
        onBasketScreensButtonClicked= {},
        onProfilePageButtonClicked = {},
        onRestaurantCardClicked = {},
        onLocationButtonClicked = {},
        navController = {}
    )
}*/