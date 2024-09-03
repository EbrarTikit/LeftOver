package com.example.leftover

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Close
import androidx.compose.material.icons.filled.Create
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Card
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.RadioButton
import androidx.compose.material3.RadioButtonDefaults
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.leftover.Data.AddressesData
import com.example.leftover.Data.AllAddress


@Composable
fun SavedLocationsScreen(
    onBackButtonClicked: () -> Unit,
    onNewLocationButtonClicked: () -> Unit,
    onEditButtonClicked:() -> Unit,
    viewModel: FoodLeftOverViewModel= viewModel()
) {


    val locationList by viewModel.addressList.observeAsState(initial = emptyList())
    Surface(
        color = colorResource(id = R.color.white),
    ) {






        //val locationList = viewModel.address

        /*if (locationList == null) {
            // Handle the empty state
            println("No data available")
        }*/

        Column(
            modifier = Modifier
                .fillMaxSize()

        ) {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                modifier = Modifier
                    .background(color = colorResource(id = R.color.Alabaster))
                    .padding(top = 10.dp)
            ) {
                IconButton(onClick = { onBackButtonClicked() }) {
                    Icon(Icons.Filled.Close, contentDescription = null )
                }
                Spacer(modifier = Modifier.weight(0.05f))
                Text(text = "Saved Locations")
                Spacer(modifier = Modifier.weight(1f))
            }
            Row {
                Spacer(modifier = Modifier.weight(1f))
                Button(
                    onClick = { onNewLocationButtonClicked() },
                    colors = ButtonDefaults.buttonColors( containerColor = colorResource(id = R.color.Alabaster))
                ) {
                    Icon(Icons.Filled.Add, contentDescription = null, tint = colorResource(id = R.color.Blue) )
                    Text(text = "New Location", color = colorResource(id = R.color.Blue))
                }
                Spacer(modifier = Modifier.weight(1f))
            }
            if (locationList.isEmpty()) {
                Text("No saved locations available.", modifier = Modifier.padding(16.dp))
            } else {
                LocationList(locationList = locationList)
            }
        }
    }
}

@Composable
fun LocationCard(
    locationName:String,
    locationDescription:String,

    )
{Box(
    modifier = Modifier
        .background(color = colorResource(id = R.color.Alabaster))
        .padding(10.dp)
        .fillMaxWidth(0.8f)
) {
    Row(
        modifier = Modifier
    ) {
        RadioButton(
            selected = true,
            onClick = { },
            colors = RadioButtonDefaults.colors(unselectedColor = colorResource(id = R.color.Blue),selectedColor = colorResource(id = R.color.Blue))
        )
        Spacer(modifier = Modifier.weight(0.1f))
        Column {
            Text(text = "Home", fontWeight = FontWeight.Bold)
            Text(text = "Lorem ipsum sit dolar upset")
            Text(text = "Lorem ipsum sit dolar upset")
            Text(text = "054167**7")
        }
        Spacer(modifier = Modifier.weight(0.1f))
        IconButton(onClick = {  }
        ) {
            Icon(Icons.Filled.Create, contentDescription = null, tint = colorResource(id = R.color.Blue) )
        }
    }
}

}

@Composable
fun LocationList(
    locationList:List<AllAddress>,

    )
{
    LazyColumn() {
        items(locationList){location->
            LocationCard(locationName = location.addressTitle, locationDescription =location.addressDefinition )

        }

    }
}

@Preview
@Composable
fun SavedLocationsScreenPreview() {
    SavedLocationsScreen(
        onBackButtonClicked = {},
        onNewLocationButtonClicked = {},
        onEditButtonClicked={}
    )
}