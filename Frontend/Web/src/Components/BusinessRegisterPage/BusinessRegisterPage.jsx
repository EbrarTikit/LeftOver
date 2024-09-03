import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import $ from "jquery";
import "./BusinessRegisterPage.css";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import Menu from "../../Assets/images/menu.jpg";
import { useEffect } from "react";

const BusinessRegisterPage = () => {
  const [storeName, setStoreName] = useState("");
  const [storeType, setStoreType] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [address, setAddress] = useState("");
  const [postalCode, setPostalCode] = useState("");
  const [city, setCity] = useState("");
  const [country, setCountry] = useState("");
  const [passwordError, setPasswordError] = useState("");
  const [errors, setErrors] = useState({});

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setErrors({ ...errors, password: "Passwords do not match" });
      return;
    }

    setErrors({});

    $.ajax({
      url: "https://foodleftoversaver.azurewebsites.net/api/v1/Restaurant/create/restaurant",
      type: "POST",
      contentType: "application/json;",
      dataType: "json",
      data: JSON.stringify({
        name: storeName,
        email: email,
        password: password,
        phoneNumber: phoneNumber,
        streetInformation: address,
        city: city,
        postalCode: postalCode,
        country: country,
        storeType: storeType,
      }),
      success: function (response) {
        navigate("/sign-in"); // Redirect to the /database page
      },
      error: function (error) {
        const errorResponse = error.responseJSON;
        if (errorResponse && errorResponse.errors) {
          const newErrors = {};
          Object.keys(errorResponse.errors).forEach((key) => {
            newErrors[key.toLowerCase()] = errorResponse.errors[key][0];
          });
          setErrors(newErrors);
        }
      },
    });
  };

  useEffect(() => {
    document.title = "FoodLeftover | Business Register Page";
  }, []);

  return (
    <>
      <Header />
      <div className="main-header">
        <h1>Register Your Business</h1>
      </div>
      <img className="menu " src={Menu} alt="Menu" />
      <form className="form" onSubmit={handleSubmit}>
        <div className="informations">
          <div className="store-name">
            <input
              type="text"
              placeholder="Store Name"
              value={storeName}
              onChange={(e) => setStoreName(e.target.value)}
            />
            {errors.name && <div className="error">{errors.name}</div>}
          </div>
          <div className="store-type">
            <input
              type="text"
              placeholder="Store Type"
              value={storeType}
              onChange={(e) => setStoreType(e.target.value)}
            />
            {errors.storetype && (
              <div className="error">{errors.storetype}</div>
            )}
          </div>
          <div className="phone-number">
            <input
              type="text"
              placeholder="Phone Number"
              value={phoneNumber}
              onChange={(e) => setPhoneNumber(e.target.value)}
            />
            {errors.phonenumber && (
              <div className="error">{errors.phonenumber}</div>
            )}
          </div>
          <div className="email">
            <input
              type="text"
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            {errors.email && <div className="error">{errors.email}</div>}
          </div>
          <div className="password">
            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            {errors.password && <div className="error">{errors.password}</div>}
          </div>
          <div className="confirm-password">
            <input
              type="password"
              placeholder="Confirm Password"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </div>
        </div>
        <div className="address-info">
          <div className="address">
            <input
              type="text"
              placeholder="Address"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
            {errors.streetinformation && (
              <div className="error">{errors.streetinformation}</div>
            )}
          </div>
          <div className="except-address">
            <div className="postal-code">
              <input
                type="text"
                placeholder="Postal Code"
                value={postalCode}
                onChange={(e) => setPostalCode(e.target.value)}
              />
              {errors.postalcode && (
                <div className="error">{errors.postalcode}</div>
              )}
            </div>
            <div className="city">
              <input
                type="text"
                placeholder="City"
                value={city}
                onChange={(e) => setCity(e.target.value)}
              />
              {errors.city && <div className="error">{errors.city}</div>}
            </div>
            <div className="country">
              <input
                type="text"
                placeholder="Country"
                value={country}
                onChange={(e) => setCountry(e.target.value)}
              />
              {errors.country && <div className="error">{errors.country}</div>}
            </div>
          </div>
        </div>
        <div className="submit-button">
          <button type="submit">Register</button>
        </div>

        <Footer> </Footer>
      </form>
    </>
  );
};

export default BusinessRegisterPage;
