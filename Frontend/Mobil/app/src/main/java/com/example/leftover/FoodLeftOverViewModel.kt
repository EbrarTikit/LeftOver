package com.example.leftover



import android.util.Log
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.leftover.Data.AllAddress
import com.example.leftover.Data.AllRestaurant
import com.example.leftover.Data.AuthenticateResponse
import com.example.leftover.Data.LogIn
import com.example.leftover.Data.RestaurantById
import com.example.leftover.Data.SignUp
import com.example.leftover.Data.response
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import java.io.IOException

class FoodLeftOverViewModel: ViewModel() {

    private val _restaurantList = MutableLiveData<List<AllRestaurant>>()
    val restaurantList: LiveData<List<AllRestaurant>> get() = _restaurantList

    private val _restaurant = MutableLiveData<RestaurantById>()
    val restaurant: LiveData<RestaurantById> get() = _restaurant

    private val _addressList = MutableLiveData<List<AllAddress>>()
    val addressList: LiveData<List<AllAddress>> get() = _addressList

    var registrationStatus by mutableStateOf<List<String>?>(null)
        private set

    var authenticationStatus by mutableStateOf<String>("")
        private set




    init {
        viewModelScope.launch {
            getAllRestaurant()
            getAllAddresses()

            //getRestaurantById(1)

        }
    }

    fun loadRestaurantById(restaurantId: Int) {
        viewModelScope.launch {
            Log.d("FoodLeftOverViewModel", "Loading restaurant by ID: $restaurantId")
            getRestaurantById(restaurantId)
        }
    }

    private suspend fun getAllRestaurant(){
        try {
            val response = RetrofitClient.foodLeftOverApiService.getAllRestaurants()
            if (response.succeeded) {
                _restaurantList.postValue(response.data)
            } else {
                // Handle the error case
                _restaurantList.postValue(emptyList())
            }
        } catch (e: Exception) {
            // Handle the exception
            _restaurantList.postValue(emptyList())
        }
    }

    private suspend fun getAllAddresses() {
        try {
            val response = RetrofitClient.foodLeftOverApiService.getAllAddresses()
            if (response.succeeded) {
                _addressList.postValue(response.data)
            } else {
                _addressList.postValue(emptyList())
            }
        } catch (e: Exception) {
            _addressList.postValue(emptyList())
        }
    }

    private suspend fun getRestaurantById(restaurantId: Int){

            try {
                val response = RetrofitClient.foodLeftOverApiService.getRestaurantById(id = restaurantId)
                if (response.succeeded) {
                    _restaurant.postValue(response.data)
                } else {
                    // Handle the error case
                    System.out.println("Restaurant not found")
                }
            } catch (e: Exception) {
                // Handle the exception
                System.out.println("Exception")
            }
    }


    fun registerUser(registerRequest: SignUp) {
        viewModelScope.launch {
            try {
                val registrationStatus = RetrofitClient.foodLeftOverApiService.registerUser(registerRequest)
                // Handle response if needed
                // After successful registration, navigate to the login screen

            } catch (e: Exception) {
                // Handle error
            }
        }
    }



    fun authenticateUser(authenticationRequest: LogIn) {
        viewModelScope.launch {
            try {
                val auth = RetrofitClient.foodLeftOverApiService.authenticateUser(authenticationRequest)
                if (auth.succeeded) {
                    val authenticateResponse = auth.data
                    authenticationStatus = "Authentication successfull"
                    // Check if the user is verified and has a valid token
                    //onResult(authenticateResponse.isVerified && authenticateResponse.jwToken.isNotEmpty())
                } else {
                    authenticationStatus = "Authentication failed"
                   // onResult(false)
                }
            } catch (e: Exception) {
                authenticationStatus = "Failure"
                //onResult(false)
            }
        }
    }



}
