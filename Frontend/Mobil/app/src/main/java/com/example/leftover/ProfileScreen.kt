package com.example.leftover

import android.icu.text.UnicodeSet.SpanCondition
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.AccountCircle
import androidx.compose.material.icons.filled.AddCircle
import androidx.compose.material.icons.filled.Create
import androidx.compose.material.icons.filled.KeyboardArrowRight
import androidx.compose.material3.Button
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.ModalBottomSheet
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp


@Composable
fun ProfileScreen(
    onHomePageButtonClicked: () -> Unit,
    onFavouritePageButtonClicked: () -> Unit,
    onBasketScreensButtonClicked: () -> Unit,
    onProfilePageButtonClicked: () -> Unit,
    onLogOutButtonClicked:() -> Unit,
    onLocationButtonClicked: () -> Unit
) {
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
            ProfileInfo(
                onLogOutButtonClicked = onLogOutButtonClicked
            )
        }

    }
}

@Composable
fun ProfileInfo(
    modifier: Modifier = Modifier,
    onLogOutButtonClicked:() -> Unit
) {
    Column(
        modifier = Modifier
            .padding(10.dp)
            .height(610.dp),
    ) {
        Box(
            modifier = Modifier
                .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp))
                .fillMaxWidth()
                .background(colorResource(id = R.color.SkyBlue))
                .height(40.dp)

        ) {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                horizontalArrangement = Arrangement.Center,
                modifier = Modifier.padding(10.dp)
            ) {
                Text(text = "Name Surname", fontSize = 15.sp)
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.AccountCircle, contentDescription = null)
            }
        }
        Spacer(modifier = Modifier.weight(1f))
        Box(modifier = Modifier
            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp))
            .fillMaxWidth()
            .background(colorResource(id = R.color.SkyBlue))
            .padding(10.dp)
        ) {
                Column {
                    Row {
                        Column {
                            Text(text = "Account Settings", fontSize = 20.sp)
                            Text(text = "Name Surname : Merve Çetin")
                            Text(text = "E-mail: asda@gmail.com")
                            Text(text = "Phone Number: 555 555 55 55")
                        }
                        Spacer(modifier = Modifier.weight(1f))
                        Column {
                            IconButton(onClick = { /*TODO*/ }) {
                                Icon(Icons.Filled.Create, contentDescription = null )
                            }
                        }
                    }
                }
        }
        Spacer(modifier = Modifier.weight(1f))
        Box(modifier = Modifier
            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp))
            .fillMaxWidth()
            .background(colorResource(id = R.color.SkyBlue))
            .padding(10.dp)
        ) {
            Column {
                Row(verticalAlignment = Alignment.CenterVertically) {
                    Text(text = "Locations")
                    Spacer(modifier = Modifier.padding(10.dp))
                    IconButton(onClick = { /*TODO*/ }) {
                        Icon(Icons.Filled.AddCircle, contentDescription = null)
                    }
                }
                Text(text = "Home: Kepez Mh.")
                Text(text = "Workplace: Konyaaltı Mh.")
            }
        }
        Spacer(modifier = Modifier.weight(1f))
        Box(modifier = Modifier
            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp))
            .fillMaxWidth()
            .background(colorResource(id = R.color.SkyBlue))
            .padding(10.dp)
        ) {
            Row {
                Text(text = "Reservations")
                Spacer(modifier = Modifier.weight(1f))
                Icon(Icons.Filled.KeyboardArrowRight, contentDescription = null )
            }

        }
        Spacer(modifier = Modifier.weight(1f))
        Row {
            Spacer(modifier = Modifier.weight(1f))
            Button(onClick ={ onLogOutButtonClicked() }) {
                Text(text = "Log Out")
            }
            Spacer(modifier = Modifier.weight(1f))
        }
    }
}


@Preview
@Composable
fun ProfileScreenPreview() {
    ProfileScreen(
        onHomePageButtonClicked = {},
        onFavouritePageButtonClicked = {},
        onBasketScreensButtonClicked = {},
        onProfilePageButtonClicked = {},
        onLogOutButtonClicked = {},
        onLocationButtonClicked = {}
    )
}













