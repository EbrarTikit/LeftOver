package com.example.leftover

import com.example.leftover.Data.AddressesData
import com.example.leftover.Data.AllRestaurantData
import com.example.leftover.Data.AuthenticateResponse
import com.example.leftover.Data.LogIn
import com.example.leftover.Data.RegisterResponse
import com.example.leftover.Data.RestaurantByIdData
import com.example.leftover.Data.SignUp
import com.example.leftover.Data.response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path
import retrofit2.http.Query

interface FoodLeftOverApiService {
    @GET("/api/v{version}/Restaurant")
    suspend fun getAllRestaurants(
        @Path("version") version: String? = "1",
        @Query("PageNumber") pageNumber: Int? = 1,
        @Query("PageSize") pageSize: Int? = 5
    ): AllRestaurantData
/*
    @GET("/api/v{version}/Restaurant/getby/{id}")
    suspend fun getRestaurantById(
        @Path("version") version: String = "1",
        @Path("id") id: Int? ,
    ): RestaurantByIdData
*/
    @GET("/api/v{version}/Restaurant/getby/{id}")
    suspend fun getRestaurantById(
        @Path("version") version: String = "1",
        @Path("id") id: Int,
    ): RestaurantByIdData

    @POST("/api/Account/register")
    suspend fun registerUser(
        @Body registerRequest: SignUp
    ): RegisterResponse


    @POST("/api/Account/authenticate")
    suspend fun authenticateUser(
        @Body authenticationRequest: LogIn
    ): response

    @GET("api/v{version}/Address")
    suspend fun getAllAddresses(
        @Path("version") version: String = "1",
        @Query("PageNumber") pageNumber: Int? = 1,
        @Query("PageSize") pageSize: Int? = 5,
        @Query("userName") userName: String = "cetinn"
    ): AddressesData

}


