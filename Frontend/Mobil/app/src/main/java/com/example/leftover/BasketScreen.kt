package com.example.leftover


import android.view.textservice.SpellCheckerInfo
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.AccountCircle
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Delete
import androidx.compose.material.icons.filled.Favorite
import androidx.compose.material.icons.filled.Home
import androidx.compose.material.icons.filled.ShoppingCart
import androidx.compose.material.icons.filled.Star
import androidx.compose.material3.Button
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import javax.sql.RowSetMetaData


@Composable
fun BasketScreen(
    modifier: Modifier = Modifier,
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onReservationScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onReserveButtonClicked: () -> Unit,
    onLocationButtonClicked: () -> Unit
){
    Surface(
        color = colorResource(id = R.color.Alabaster)
    ) {
        Column(modifier = Modifier.fillMaxSize()) {
            UpPart(onLocationButtonClicked)
            BasketInfo(
                modifier = Modifier,
                onReserveButtonClicked = onReservationScreensButtonClicked
            )
            BottomPart(
                onHomePageButtonClicked = onHomePageButtonClicked,
                onFavouritePageButtonClicked = onFavouritePageButtonClicked,
                onBasketScreensButtonClicked = onReservationScreensButtonClicked,
                onProfilePageButtonClicked = onProfilePageButtonClicked
            )
        }
    }
}

@Composable
fun BasketInfo(
    modifier: Modifier= Modifier,
    onReserveButtonClicked: () -> Unit
) {

    Column(modifier = Modifier
        .padding(top = 30.dp, start = 15.dp, end = 15.dp),
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        Row(modifier = Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically) {
            Box(
                modifier = Modifier
                    .background(colorResource(id = R.color.SkyBlue))
                    .fillMaxWidth(0.5f)
                    .height(50.dp)
            ){
                Text(text = "Restaurant Name", modifier= Modifier
                    .fillMaxSize()
                    .padding(start = 10.dp, top = 15.dp, bottom = 10.dp))
            }
            Spacer(modifier = Modifier.weight(1f))
            IconButton(onClick = { /*TODO*/ }) {
                Icon(Icons.Filled.Delete, contentDescription = null, modifier =Modifier.size(50.dp))
            }
        }

        Spacer(modifier = Modifier.padding(10.dp))
        Box(
            modifier = Modifier
                .background(colorResource(id = R.color.SkyBlue))
                .fillMaxWidth()
                .height(80.dp)
        ){
            Row(
                verticalAlignment = Alignment.CenterVertically,
                horizontalArrangement = Arrangement.Center,
                modifier = modifier.padding(10.dp)

            ) {
                Column() {
                    Text(text = "Name of Food")
                    Spacer(modifier = Modifier.weight(1f))
                    Text(text = "Price")
                }
                Spacer(modifier = Modifier.weight(1f))
                IconButton(onClick = { /*TODO*/ }) {
                    Icon(Icons.Filled.Add, contentDescription = null )
                }
                Text(text = "0")
                IconButton(onClick = { /*TODO*/ }) {
                    Icon(Icons.Filled.Delete, contentDescription = null )
                }


            }
        }

        Spacer(modifier = Modifier.padding(160.dp))

        Text(text = "Reservations will be canceled after 1 hour",modifier = Modifier.background(
            Color.LightGray))

        Spacer(modifier = Modifier.padding(5.dp))
        Box(
            modifier = Modifier
                .background(colorResource(id = R.color.SkyBlue))
                .fillMaxWidth()
                .height(50.dp)
                .padding(10.dp)
        ) {
            Row(
                modifier = Modifier.fillMaxWidth(),
                verticalAlignment = Alignment.CenterVertically,
                horizontalArrangement = Arrangement.Center) {
                Text(text = "Total Cost to pay")
                Spacer(modifier = Modifier.weight(1f))
                Button(onClick = onReserveButtonClicked) {
                    Text(text = "Reserve")
                }
            }
        }
        Spacer(modifier = Modifier.padding(5.dp))
    }

}




@Preview
@Composable
fun BasketScreenPreview(){
    BasketScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onReservationScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onReserveButtonClicked = {},
        onLocationButtonClicked = {}
    )
}






















