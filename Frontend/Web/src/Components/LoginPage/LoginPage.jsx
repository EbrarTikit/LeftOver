import React, { useState, useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import $ from "jquery";
import "./LoginPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import Login from "../../Assets/images/Login.jpg";
import { useEffect } from "react";

import { AuthContext } from "../../AuthContext";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordError, setPasswordError] = useState("");

  const { login } = useContext(AuthContext);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = "FoodLeftover | Login";
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add authentication logic here

    $.ajax({
      url: "https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/signin",
      type: "POST",
      contentType: "application/json;",
      dataType: "json",
      data: JSON.stringify({
        email: email,
        password: password,
      }),
      success: function (response) {
        login("default token", response.id); // Assuming the response contains a token
        navigate("/database"); // Redirect to the /database page
      },
      error: function (error) {
        setPasswordError(error.responseJSON.message);
      },
    });
  };

  return (
    <>
      <Header />
      <div className="login-page">
        <div className="login-container">
          <div className="left-column">
            <h2 className="caption">Sign In To Your Account</h2>
            <div className="input-container">
              <input
                className="email-input"
                type="text"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                required
              />
              <input
                className="password-input"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
                required
              />
              {passwordError && (
                <div
                  style={{
                    marginLeft: "1rem",
                    fontStyle: "italic",
                    marginBottom: "1rem",
                  }}
                  className="passwordError"
                >
                  {passwordError}
                </div>
              )}
            </div>
            <div className="forgot-password">
              <Link to="/forgot-password">Forgot Password?</Link>
            </div>
            <div className="buttons">
              <button className="login-button" onClick={handleSubmit}>
                Sign In
              </button>
              <Link to="/sign-up">
                <button>Sign Up</button>
              </Link>
            </div>
          </div>

          <div className="right-column">
            <img src={Login} alt="Login" />
          </div>
        </div>
      </div>
      <Footer />
    </>
  );
};

export default LoginPage;
