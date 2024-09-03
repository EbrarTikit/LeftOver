package com.example.leftover

import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.currentBackStackEntryAsState
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument


enum class LeftOverScreen() {
    LogIn,SignUp,HomePage,DesiredStore,Filter,Restaurant,Basket,Profile,Reservations,ReservationsDetails,Favourite,AccountSettings,NewLocation,SavedLocations
}



@Composable
fun LeftOverApp() {

    val navController = rememberNavController()

    val backStackEntry by navController.currentBackStackEntryAsState()

    NavHost(
        navController = navController,
        startDestination = "SignUp"
    ) {
        composable(route = "Login") {
            LogInScreen(
                onLogInButtonClicked = {
                    navController.navigate("HomePage")
                },
                onSignUpButtonClicked = {
                    navController.navigate("SignUp")
                },
            )
        }
        composable(route = "SignUp") {
            SignUpScreen(
                onLogInButtonClicked = {
                    navController.navigate("Login")
                },
                onSignUpButtonClicked = {
                    navController.navigate("HomePage")
                }
            )
        }

        composable(route = "HomePage") {
            HomePageScreen(
                onHomePageButtonClicked = {
                    navController.navigate( "HomePage")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onBasketScreensButtonClicked = {
                    navController.navigate("Basket")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onRestaurantCardClicked = {
                    navController.navigate("Restaurant/{restaurantId}")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                },
                navController = navController
            )
        }

        composable(route = "DesiredStore") {
            DesiredStoreScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onBasketScreensButtonClicked = {
                    navController.navigate("Basket")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onFilterRowClicked = {
                    navController.navigate("Filter")
                },
                onRestaurantBoxClicked = {
                    navController.navigate("Restaurant")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                }
            )
        }

        composable(route = "Filter") {
            FilterScreen(
            )
        }

        composable(route = "Restaurant/{restaurantId}",
            arguments = listOf(
                navArgument(name = "restaurantId"){
                    type = NavType.IntType
                }
            )
        ) {index ->
            RestaurantScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onBasketScreensButtonClicked = {
                    navController.navigate("Basket")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                },
                restaurantId = index.arguments?.getInt("restaurantId"),
                navController = navController

            )
        }

        composable(route = "Basket") {
            BasketScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onReservationScreensButtonClicked = {
                    navController.navigate("Reservations")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onReserveButtonClicked = {
                    navController.navigate("Restaurant")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                }
            )
        }

        composable(route = "Profile") {
            ProfileScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onBasketScreensButtonClicked = {
                    navController.navigate("Basket")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onLogOutButtonClicked = {
                    navController.navigate("LogIn")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                }
            )
        }

        composable(route = "Reservations") {
            ReservationsScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onReservationScreensButtonClicked = {
                    navController.navigate("Reservations")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onGoBackButtonClicked = {
                    navController.navigate("HomePage")
                },
                onDetailsButtonClicked = {
                    navController.navigate("ReservationsDetails")
                }
            )
        }

        composable(route = "ReservationsDetails") {
            ReservationsDetailsScreen(
                onHomePageButtonClicked = {
                    navController.navigate("HomePage")
                },
                onReservationScreensButtonClicked = {
                    navController.navigate("Reservations")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onGoBackButtonClicked = {
                    navController.navigate("Reservations")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations.name")
                }
            )
        }

        composable(route =  "Favourite") {
            FavouriteScreen(
                onHomePageButtonClicked = {
                    navController.navigate( "HomePage")
                },
                onBasketScreensButtonClicked = {
                    navController.navigate("Basket")
                },
                onFavouritePageButtonClicked = {
                    navController.navigate("Favourite")
                },
                onProfilePageButtonClicked = {
                    navController.navigate("Profile")
                },
                onRestaurantBoxClicked = {
                    navController.navigate("Restaurant")
                },
                onLocationButtonClicked = {
                    navController.navigate("SavedLocations")
                }
            )
        }

        composable(route = "AccountSettings") {
            AccountSettingsScreen(
                onLocationsButtonClicked = {
                    navController.navigate("SavedLocations") },
                onSaveButtonClicked = {
                    navController.navigate("Profile")
                }
            )
        }

        composable(route = "NewLocation") {
            NewLocationScreen(
                onBackButtonClicked = { navController.navigate("SavedLocations") },
                onSaveMyLocationButtonClicked = { navController.navigate("SavedLocations") }
            )
        }

        composable(route = "SavedLocations") {
            SavedLocationsScreen(
                onBackButtonClicked = { navController.navigate("HomePage") },
                onNewLocationButtonClicked = { navController.navigate("NewLocation") },
                onEditButtonClicked = { navController.navigate("NewLocation") }
            )
        }




    }



}


