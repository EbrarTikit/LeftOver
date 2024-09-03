package com.example.leftover

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.WindowInsets
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.safeDrawing
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.core.splashscreen.SplashScreen.Companion.installSplashScreen
import androidx.core.view.WindowCompat
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.leftover.ui.theme.LeftOverTheme
import com.squareup.moshi.Json

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        installSplashScreen()
        getActionBar()?.hide()

        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            LeftOverTheme {
                LeftOverApp()
            }
        }
    }

}

@Composable
fun WizardData(modifier: Modifier = Modifier, viewModel: FoodLeftOverViewModel = androidx.lifecycle.viewmodel.compose.viewModel()) {
    val data = viewModel.restaurant.observeAsState().value.toString()
    val datax = viewModel.restaurantList.observeAsState().value.toString()
    if(data != null) {
        Text(text = datax)
    }

}



@Preview(showBackground = true)
@Composable
fun LeftOverAppPreview() {
    LeftOverTheme {
        WizardData()
    }
}