package com.example.leftover.Data

data class AllRestaurantData(
    val succeeded: Boolean,
    val message: String ?= null,
    val errors: List<String> ?= null,
    val data: List<AllRestaurant>,
    val pageNumber: Int,
    val pageSize: Int
)

data class AddressesData(
    val data: List<AllAddress> ,
    val errors: List<String> ?= null,
    val message: String ?= null,
    val pageNumber: Int ,
    val pageSize: Int ,
    val succeeded:Boolean
)
data class RestaurantByIdData(
    val succeeded: Boolean,
    val message: String ?= null,
    val errors: List<String> ?= null,
    val data: RestaurantById,
)

data class RegisterResponse(
    val succeeded: Boolean,
    val message: String,
    val errors: List<String>?,
    val data: String?
)

data class AuthenticateResponse(
    val email: String,
    val id: String,
    val isVerified: Boolean,
    val jwToken: String,
    val roles: List<Any>,
    val userName: String
)

data class response(
    val `data`: AuthenticateResponse,
    val errors: Any,
    val message: String,
    val succeeded: Boolean
)
