package com.example.leftover

import android.window.SplashScreen
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.Surface
import androidx.compose.material3.contentColorFor
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.tooling.preview.Preview


@Composable
fun SplashScreen() {
    Surface(
        color = colorResource(id = R.color.Alabaster),
        modifier = Modifier.fillMaxSize()
        ) {
        Column(verticalArrangement = Arrangement.Center, horizontalAlignment = Alignment.CenterHorizontally) {
            Image(painter = painterResource(id = R.drawable.foodleftover), contentDescription = null )
        }
    }
}

@Preview
@Composable
fun SplashScreenPreview() {
    SplashScreen()
}