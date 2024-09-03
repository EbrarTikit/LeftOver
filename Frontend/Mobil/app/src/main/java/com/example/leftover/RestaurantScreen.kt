package com.example.leftover

import android.util.Log
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.offset
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.safeDrawingPadding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.AccountCircle
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Favorite
import androidx.compose.material.icons.filled.Home
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.material.icons.filled.ShoppingCart
import androidx.compose.material.icons.filled.Star
import androidx.compose.material.icons.outlined.AccountCircle
import androidx.compose.material.icons.outlined.Favorite
import androidx.compose.material.icons.outlined.Home
import androidx.compose.material.icons.outlined.ShoppingCart
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.OutlinedTextFieldDefaults
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import com.example.leftover.Data.AllRestaurant
import com.example.leftover.Data.RestaurantById


@Composable
fun RestaurantScreen(
    modifier: Modifier = Modifier,
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onBasketScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onLocationButtonClicked: () -> Unit,
    viewModel: FoodLeftOverViewModel = viewModel(),
    navController: NavController,
    restaurantId: Int?
) {

    //val restaurant by viewModel.restaurant.observeAsState()
    val context = LocalContext.current
    LaunchedEffect(restaurantId) {
        if (restaurantId != null) {
            Log.d("RestaurantScreen", "Loading restaurant with ID: $restaurantId")
            viewModel.loadRestaurantById(restaurantId)
        } else {
            Log.d("RestaurantScreen", "No restaurant ID provided")
        }
    }

    val restaurant by viewModel.restaurant.observeAsState()

    //System.out.println(restaurant!!.name)

    Scaffold(
        topBar = { UpPart (onLocationButtonClicked = onLocationButtonClicked) },
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
            if (restaurant != null) {
                RestaurantInfo(restaurant!!)
            } else {
                // You can display a loading indicator or a placeholder here
                Text("Loading...")
            }
        }
    }
}

@Composable
fun RestaurantInfo(restaurant: RestaurantById) {
    Column(
        modifier = Modifier.padding(top = 30.dp, start = 15.dp, end = 15.dp)
    ) {
        Box(
            modifier = Modifier
                .background(colorResource(id = R.color.SkyBlue))
                .fillMaxWidth()
                .height(100.dp),
        ){
            Row(
                verticalAlignment = Alignment.CenterVertically,
                horizontalArrangement = Arrangement.Center,
                modifier = Modifier
                    .fillMaxSize()
                    .padding(10.dp)
            ) {
                Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null,modifier = Modifier.size(60.dp))
                Spacer(modifier = Modifier.padding(5.dp))
                Column(modifier = Modifier
                    .fillMaxSize()
                ) {
                    Row(
                        modifier = Modifier.padding(top = 5.dp),
                        verticalAlignment = Alignment.CenterVertically,
                        horizontalArrangement = Arrangement.Center,
                        ) {
                        if (restaurant != null) {
                            Text(text = restaurant.name)
                        }
                        Spacer(modifier = Modifier.weight(1f))
                        IconButton(onClick = { /*TODO*/ }) {
                            Icon(Icons.Filled.Favorite, contentDescription = null)
                        }
                    }
                    Spacer(modifier = Modifier.weight(1f))
                    Row(
                        modifier = Modifier.padding(bottom = 5.dp),
                        verticalAlignment = Alignment.CenterVertically,
                        horizontalArrangement = Arrangement.Center,
                    ) {
                        Icon(Icons.Filled.Star, contentDescription = null )
                        Spacer(modifier = Modifier.weight(0.5f))
                        Text(text = "Rate")
                        Spacer(modifier = Modifier.weight(1f))
                        Text(text = "Hours")
                    }
                }
            }
        }

        Spacer(modifier = Modifier.padding(15.dp))

        Box(
            modifier = Modifier
                .background(colorResource(id = R.color.SkyBlue))
                .fillMaxWidth()
                .height(80.dp)
                .padding(10.dp)
        ){
            Text(text = "Campaigns and Coupons")
        }

        Spacer(modifier = Modifier.padding(10.dp))

        Box(
            modifier = Modifier
                .background(colorResource(id = R.color.SkyBlue))
                .fillMaxWidth()
                .height(100.dp)
                .padding(10.dp)
        ){
            Row(
                modifier = Modifier

                    .fillMaxSize()
            ) {
                Column {
                    Text(text = "Food Name")
                    Spacer(modifier = Modifier.weight(1f))
                    Text(text = "Food Ingrediants")
                    Spacer(modifier = Modifier.weight(1f))
                    IconButton(onClick = { /*TODO*/ }) {
                        Icon(Icons.Filled.Add, contentDescription = null )
                    }

                }
                Spacer(modifier = Modifier.weight(1f))
                Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null,modifier = Modifier.size(80.dp))
            }
        }
    }
}

@Composable
fun RestaurantItemList(restaurantItemList: List<RestaurantById>, modifier: Modifier,navController: NavController ){
    LazyColumn(modifier = modifier) {
        items(restaurantItemList) { restaurant ->
            RestaurantCard(
                onRestaurantCardClicked = {},
                restaurantName = restaurant.name,
                restaurantType = restaurant.storeType,
                restaurantId = restaurant.id,
                navController = navController
                )

        }
    }
}

@Composable
fun UpPart(
    onLocationButtonClicked: () -> Unit
) {
    Column(
        modifier = Modifier
            .fillMaxWidth()
            .background(color = colorResource(id = R.color.white))
            .safeDrawingPadding()
    ) {
        Row(modifier = Modifier.fillMaxWidth()) {
            Spacer(modifier = Modifier.weight(0.5f))
            Column {
                Button(
                    onClick = { onLocationButtonClicked() },
                    modifier = Modifier.padding(5.dp),
                    colors = ButtonDefaults.buttonColors(colorResource(id = R.color.SkyBlue))
                ) {
                    Text(text = "Location")
                    Icon(Icons.Filled.KeyboardArrowDown, contentDescription = null )
                }
                OutlinedTextField(
                    value = "Search",
                    onValueChange = {},
                    colors = OutlinedTextFieldDefaults.colors(colorResource(id = R.color.Alabaster)),
                    modifier = Modifier.background(colorResource(id = R.color.Alabaster))

                )
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

    }
}

/*
@Preview
@Composable
fun RestaurantScreenPreview() {
    RestaurantScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onBasketScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onLocationButtonClicked = {},
        restaurantId = 1,
        navController = null
    )
}

 */


@Composable
fun BottomPart(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onBasketScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
) {
    Row(
        modifier = Modifier
            .height(60.dp)
            .fillMaxWidth()
            .background(colorResource(id = R.color.SkyBlue)),
        horizontalArrangement = Arrangement.Center,
        verticalAlignment = Alignment.CenterVertically,
    ) {
        IconButton(onClick = onHomePageButtonClicked) {
            Icon(
                Icons.Outlined.Home,
                contentDescription = null,
                modifier = Modifier.size(40.dp),
                tint = colorResource(id = R.color.Alabaster)
            )
        }
        Spacer(modifier = Modifier.padding(horizontal = 20.dp))
        IconButton(onClick = onFavouritePageButtonClicked) {
            Icon(
                Icons.Outlined.Favorite,
                contentDescription = null,
                modifier = Modifier.size(40.dp)
            )
        }
        Spacer(modifier = Modifier.padding(horizontal = 20.dp))
        IconButton(onClick = onBasketScreensButtonClicked) {
            Icon(
                Icons.Outlined.ShoppingCart,
                contentDescription = null,
                modifier = Modifier.size(40.dp))
        }
        Spacer(modifier = Modifier.padding(horizontal = 20.dp))
        IconButton(onClick = onProfilePageButtonClicked) {
            Icon(
                Icons.Outlined.AccountCircle,
                contentDescription = null,
                modifier = Modifier.size(40.dp)
            )
        }
    }
}


@Composable
fun bottomPart(modifier: Modifier = Modifier){
        Surface(
        ) {
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.Center
            ) {
                Icon( Icons.Default.Home, contentDescription = null, modifier = Modifier.size(60.dp))
                Spacer(modifier = Modifier.padding(horizontal = 15.dp))
                Icon( Icons.Outlined.ShoppingCart, contentDescription = null, modifier = Modifier.size(60.dp) )
                Spacer(modifier = Modifier.padding(horizontal = 15.dp))
                Icon( Icons.Default.ShoppingCart, contentDescription = null, modifier = Modifier.size(60.dp))
                Spacer(modifier = Modifier.padding(horizontal = 15.dp))
                Icon( Icons.Default.AccountCircle, contentDescription = null, modifier = Modifier.size(60.dp))
            }
        }
}


