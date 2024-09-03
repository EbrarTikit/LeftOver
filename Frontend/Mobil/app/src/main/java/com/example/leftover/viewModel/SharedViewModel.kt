package com.example.leftover.viewModel

import android.view.View
import androidx.compose.runtime.remember
import androidx.lifecycle.ViewModel
import com.example.leftover.Data.RestaurantById

class SharedViewModel: ViewModel() {
    var restaurantId: Int = 1
}