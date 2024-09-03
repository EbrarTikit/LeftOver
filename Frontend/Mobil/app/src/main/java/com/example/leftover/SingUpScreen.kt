package com.example.leftover

import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.AccountCircle
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import com.example.leftover.Data.SignUp

@Composable
fun SignUpScreen(
    onLogInButtonClicked : () -> Unit,
    onSignUpButtonClicked : () -> Unit,
    viewModel: FoodLeftOverViewModel = viewModel()
){

    val firstName = remember { mutableStateOf("") }
    val lastName = remember { mutableStateOf("") }
    val userName = remember { mutableStateOf("") }
    val email = remember { mutableStateOf("") }
    val password = remember { mutableStateOf("") }
    val confirmPassword = remember { mutableStateOf("") }
    val errorMessage = remember { mutableStateOf("") }

    Surface(
        color = colorResource(id = R.color.Alabaster)
    ) {
        Column(modifier = Modifier.fillMaxSize(), horizontalAlignment = Alignment.CenterHorizontally, verticalArrangement = Arrangement.Center) {
            Image(
                painter = painterResource(id = R.drawable.foodleftover),
                contentDescription =null )
            Box(modifier = Modifier
                .clip(shape = RoundedCornerShape(15.dp, 15.dp, 15.dp, 15.dp))
            ) {
                Column(
                    verticalArrangement = Arrangement.Center,
                    horizontalAlignment = Alignment.CenterHorizontally,
                ) {
                    Icon(Icons.Filled.AccountCircle, contentDescription = null, modifier = Modifier.size(80.dp))
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = firstName.value,
                        onValueChange = {firstName.value = it},
                        placeholder = {
                            Text(
                                text = "First Name"
                            )}, modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)),
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue)))
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = lastName.value,
                        onValueChange = {lastName.value = it},
                        placeholder = {
                            Text(
                                text = "Last Name"
                            )},
                        modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)),
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue)))
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = userName.value,
                        onValueChange = {userName.value = it},
                        placeholder = {
                            Text(
                                text = "User Name"
                            )},
                        modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)),
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue
                        )) )
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = email.value,
                        onValueChange = {email.value = it},
                        placeholder = {
                            Text(
                                text = "Email"
                            )},
                        modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)) ,
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue
                        )) )
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = password.value,
                        onValueChange = {password.value = it},
                        placeholder = {
                            Text(
                                text = "Password"
                            )},
                        modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)) ,
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue
                        )) )
                    Spacer(modifier = Modifier.padding(5.dp))
                    TextField(
                        value = confirmPassword.value,
                        onValueChange = {confirmPassword.value = it},
                        placeholder = {
                            Text(
                                text = "Confirm Password"
                            )},
                        modifier = Modifier
                            .clip(shape = RoundedCornerShape(10.dp, 10.dp, 10.dp, 10.dp)) ,
                        colors = TextFieldDefaults.colors(unfocusedContainerColor = colorResource(
                            id = R.color.LightBlue,
                        )) )
                    Spacer(modifier = Modifier.padding(10.dp))
                    Button(
                        onClick = {
                            if (firstName.value.isEmpty() || lastName.value.isEmpty() || userName.value.isEmpty() || email.value.isEmpty() || password.value.isEmpty() || confirmPassword.value.isEmpty()) {
                                errorMessage.value = "All fields are required."
                            } else if (password.value != confirmPassword.value) {
                                errorMessage.value = "Passwords do not match."
                            } else {
                                viewModel.registerUser(
                                    SignUp(
                                        firstName = firstName.value,
                                        lastName = lastName.value,
                                        userName = userName.value,
                                        email = email.value,
                                        password = password.value,
                                        confirmPassword = confirmPassword.value
                                    )
                                )
                                onSignUpButtonClicked()
                            }
                        },
                        colors = ButtonDefaults.buttonColors(
                            colorResource(id = R.color.Blue))) {
                        Text(text = "Sign Up")
                    }
                    Spacer(modifier = Modifier.padding(5.dp))
                    Text(text = "Already have an account?", color = Color.Gray)
                    TextButton(onClick = { onLogInButtonClicked() }) {
                        Text(text = "Sign In", color = colorResource(id = R.color.Blue), fontWeight = FontWeight.Bold)
                    }

                }
            }
            Spacer(modifier = Modifier.weight(1f))
        }
    }

}


@Preview
@Composable
fun SignUpScreenPreview(){
    SignUpScreen(
        onSignUpButtonClicked = {},
        onLogInButtonClicked = {},
    )
}